using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SatoshiMines.Core.Models.Enums;
using SatoshiMines.Core.Providers;

namespace SatoshiMines.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly SatoshiMinesProvider _provider;

        private Player _currentPlayer;
        private Game _currentGame;

        public MainForm()
        {
            _provider = new SatoshiMinesProvider();
            InitializeComponent();

            cbMines.SelectedIndex = 0;                                                   
        }

        private async void smgMain_OnGridClicked(Guess guess)
        {
            if (_currentGame == null)
                return;

            var response = await _currentGame.TakeGuess(guess);
            if (response.Status == "success")
                smgMain.UpdateMine(guess, response.Outcome.Equals("bomb"));
            else
                MessageBox.Show(response.Message);
        }

        private async void smgMain_OnStartClicked(object sender, EventArgs e)
        {
            if (cbPlayerHash.Checked && !_currentPlayer.Custom)
            {
                if (Regex.IsMatch(tbPlayerHash.Text, "^[a-zA-Z0-9]{40}$"))
                    _currentPlayer = await _provider.CreatePlayer(tbPlayerHash.Text);
                else
                    MessageBox.Show(@"Please enter a valid player hash to play.");
            }                                                                     
            else if (_currentPlayer == null)
                _currentPlayer = await _provider.CreatePlayer();

            _currentGame = await _currentPlayer.CreateGame((int) nudBits.Value, GetMines());
        }

        private Mines GetMines()
        {
            switch (cbMines.SelectedIndex)
            {
                case 0: return Mines.One;
                case 1: return Mines.Three;
                case 2: return Mines.Five;
                case 3: return Mines.TwentyFour;
                default: return Mines.Three;
            }
        }

        private void cbPlayerHash_CheckedChanged(object sender, EventArgs e)
        {
            tbPlayerHash.Enabled = cbPlayerHash.Checked;
        }
    }
}