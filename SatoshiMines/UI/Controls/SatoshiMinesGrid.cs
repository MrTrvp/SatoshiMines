﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SatoshiMines.Core.Models;
using SatoshiMines.Core.Models.Enums;
using SatoshiMines.UI.Models;
using SatoshiMines.UI.Models.Enums;
using Timer = System.Timers.Timer;

namespace SatoshiMines.UI.Controls
{
    public sealed class SatoshiMinesGrid : Control
    {
        public delegate void OnGridClickedHandler(Guess guess); 
        public event OnGridClickedHandler OnGridClicked;    
        public event EventHandler OnStartClicked;
        public event EventHandler OnCashoutClicked;

        private bool _gameStarted; 
        public bool GameStarted
        {
            get { return _gameStarted; }
            set
            {
                _gameStarted = value;
                Invalidate();
            }
        }

        private readonly Timer _timer;
        private readonly GuessTile[] _tiles; 
        private Rectangle _startRectangle;
        private Rectangle _cashOutRectangle;

        public SatoshiMinesGrid()
        {
            _timer = new Timer { Interval = 5000 };
            _timer.Elapsed += delegate
            {
                ResetTiles();
                GameStarted = false;
               
                _timer.Stop();
            };

            _tiles = Enum.GetValues(typeof(Guess)).Cast<Guess>()
                .Select(g => new GuessTile(g)).ToArray();

            DoubleBuffered = true;
        }

        public void UpdateMine(Guess guess, GuessResponse response)
        {
            var tile = _tiles.FirstOrDefault(t => t.Guess == guess);
            if (tile != null && !response.Outcome.Equals("bomb"))
            {
                tile.Type = TileType.Money;
                Invalidate();
            }    

            if (!string.IsNullOrWhiteSpace(response.Bombs))
                ShowHiddenMines(response.Bombs);
        }

        private void InvalidateTiles()
        {
            var length = Height / 5;

            var mainIndex = 0;
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    _tiles[mainIndex].Rectangle = new Rectangle(j * length, i * length, length - 2, length - 2);
                    mainIndex++;
                }
            }

            Invalidate();
        }        

        public void ShowHiddenMines(string mines)
        {
            foreach (var tile in _tiles)
            {
                if (mines.Contains(((int) tile.Guess).ToString()))
                    tile.Type = TileType.Mine;
                else
                    tile.Type = TileType.Money;
            }

            Invalidate();

            _timer.Start();
        }

        private void ResetTiles()
        {
            foreach (var tile in _tiles)
                tile.Type = TileType.Unclicked;
        }

        private static Brush BrushFromTile(GuessTile tile)
        {
            Color tileColor;
            switch (tile.Type)
            {
                case TileType.Mine:
                    tileColor = Color.FromArgb(253, 86, 93);
                    break;
                case TileType.Money:
                    tileColor = Color.FromArgb(129, 218, 102);
                    break;
                default:
                    tileColor = Color.DeepSkyBlue;
                    break;
            }
            return new SolidBrush(tileColor);
        }

        private static Cursor CursorFromBoolean(bool @bool)
        {
            return @bool ? Cursors.Hand : Cursors.Default;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            InvalidateTiles();
            base.OnHandleCreated(e);
        }

        protected override void OnResize(EventArgs e)
        {
            InvalidateTiles();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            using (var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                foreach (var tile in _tiles)
                {
                    using (var tileFillBrush = BrushFromTile(tile))
                        g.FillRectangle(tileFillBrush, tile.Rectangle);

                    g.DrawString(((byte) tile.Guess).ToString(), Font, Brushes.White, tile.Rectangle, format);
                }    

                using (var font = new Font("Arial", 12f, FontStyle.Bold))
                {
                    if (!_gameStarted)
                    {
                        _startRectangle = new Rectangle((Width - 240) / 2, Height - 60, 240, 60);

                        g.FillRectangle(Brushes.MediumSeaGreen, _startRectangle);
                        g.DrawString("START", font, Brushes.White, _startRectangle, format);
                    }
                    else
                    {
                        _cashOutRectangle = new Rectangle((Width - 140) / 2, Height - 20, 140, 20);

                        g.FillRectangle(Brushes.Gold, _cashOutRectangle);
                        g.DrawString("CASHOUT", font, Brushes.White, _cashOutRectangle, format);
                    }
                }
            }

            base.OnPaint(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!_gameStarted && _startRectangle.Contains(e.Location))
            {
                ResetTiles();

                GameStarted = true;
                OnStartClicked?.Invoke(this, null);
            }
            else if (_gameStarted && _cashOutRectangle.Contains(e.Location))
            {
                ResetTiles();

                GameStarted = false;
                OnCashoutClicked?.Invoke(this, null);
            }
            else
            {
                var tile = _tiles.FirstOrDefault(t => t.Rectangle.Contains(e.Location));
                if (tile != null)
                    OnGridClicked?.Invoke(tile.Guess);
            }

            base.OnMouseClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_gameStarted)
                Cursor = CursorFromBoolean(_startRectangle.Contains(e.Location));
            else
            {
                var tile = _tiles.FirstOrDefault(t => t.Rectangle.Contains(e.Location));
                Cursor = CursorFromBoolean(tile != null);
            }

            base.OnMouseMove(e);
        } 
    }
}