using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SatoshiMines.Core.Providers
{
    public class SatoshiMinesProvider : IDisposable
    {         
        private readonly HttpClient _client;

        public SatoshiMinesProvider()
        {                            
            _client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false,
                UseProxy = false
            })
            {
                BaseAddress = new Uri("https://satoshimines.com/")
            };
        }

        public async Task<Player> CreatePlayer(string playerHash = null)
        {
            if (!string.IsNullOrWhiteSpace(playerHash))
            {
                return new Player(_client, true)
                {
                    PlayerHash = playerHash
                };
            }

            var response = await _client.GetAsync("/newplayer.php");   
            var location = response.Headers.Location.ToString();

            var playerHashMatch = Regex.Match(location, "/play/([^/]+)/#DONT_SHARE_URL");
            if (!playerHashMatch.Success)
                return null;

            return new Player(_client)
            {
                PlayerHash = playerHashMatch.Groups[1].Value
            };          
        }   
        
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}