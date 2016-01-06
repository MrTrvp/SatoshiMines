using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using SatoshiMines.Core.Helpers;
using SatoshiMines.Core.Models;
using SatoshiMines.Core.Models.Enums;

namespace SatoshiMines.Core.Providers
{
    public class Player
    {                                
        public bool Custom { get; set; }

        public string PlayerHash { get; set; }

        public string BdValue { get; set; }


        private readonly HttpClient _client;  

        public Player(HttpClient client, bool custom = false)
        {
            _client = client;
            Custom = custom;
        }

        public async Task<Game> CreateGame(int bits, Mines mines = Mines.Three)
        {
            if (string.IsNullOrWhiteSpace(PlayerHash))
                throw new NullReferenceException("PlayerHash is empty. You must create a player first to play the game.");

            if (bits < 30)
                throw new ArgumentOutOfRangeException(nameof(bits));

            var request = new HttpRequestMessage(HttpMethod.Post, "/action/newgame.php")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"bd", BdValue },
                    {"player_hash", PlayerHash},
                    {"bet", (bits / 10000.0).ToString(CultureInfo.InvariantCulture)},
                    {"num_mines", ((byte) mines).ToString()}
                })
            };

            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var gameResponse = JsonHelper.Deserialize<GameResponse>(content); 
            return new Game(gameResponse, _client);
        }

        public async Task<int> GetBalance()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/action/refresh_balance.php")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"secret", PlayerHash}             
                })
            };

            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var balanceResponse = JsonHelper.Deserialize<RefreshBalanceResponse>(content);
            return !balanceResponse.Status.Equals("success") ? 0 : (int) (balanceResponse.Balance * 100000);
        }
    }
}