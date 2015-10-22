using System.Runtime.Serialization;

namespace SatoshiMines.Core.Models
{
    [DataContract]
    public class CashoutResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "win")]
        public int Win { get; set; }

        [DataMember(Name = "mines")]
        public string Mines { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "random_string")]
        public string RandomString { get; set; }

        [DataMember(Name = "game_id")]
        public string GameId { get; set; }
    }
}                   