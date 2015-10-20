using System.Drawing;
using SatoshiMines.Core.Models.Enums;

namespace SatoshiMines.UI.Controls
{
    public class GuessTile
    {
        public Guess Guess { get; set; }

        public Rectangle Rectangle { get; set; } = Rectangle.Empty;

        public TileType Type { get; set; } = TileType.Unclicked;

        public GuessTile(Guess guess)
        {
            Guess = guess;
        }
    }
}