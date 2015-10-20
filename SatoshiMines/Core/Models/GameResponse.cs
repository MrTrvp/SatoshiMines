using System.Runtime.Serialization; 

namespace SatoshiMines.Core.Models
{
    [DataContract]
    public class GameResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "game_hash")]
        public string GameHash { get; set; }

        [DataMember(Name = "secret")]
        public string Secret { get; set; }

        [DataMember(Name = "bet")]
        public double Bet { get; set; }

        [DataMember(Name = "stake")]
        public double Stake { get; set; }

        [DataMember(Name = "next")]
        public double Next { get; set; }

        [DataMember(Name = "betNumber")]
        public string BetNumber { get; set; }

        [DataMember(Name = "gametype")]
        public string GameType { get; set; }

        [DataMember(Name = "num_mines")]
        public int MineCount { get; set; }    
    }
}