using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using SatoshiMines.Core.Helpers;
using SatoshiMines.Core.Models;
using SatoshiMines.Core.Models.Enums;

namespace SatoshiMines.Core.Providers
{
    public class Game
    {      
        public GameResponse GameResponse { get; }   
        private readonly HttpClient _client;

        public Game(GameResponse gameResponse, HttpClient client)
        {
            GameResponse = gameResponse;
            _client = client;
        }

        public async Task<GuessResponse> TakeGuess(Guess guess)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/action/checkboard.php")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"game_hash", GameResponse.GameHash},
                    {"guess", ((byte) guess).ToString(CultureInfo.InvariantCulture)},
                    {"v04", "1" }
                })
            };

            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return JsonHelper.Deserialize<GuessResponse>(content);
        }
    }
}