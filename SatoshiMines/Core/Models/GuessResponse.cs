using System.Runtime.Serialization;

namespace SatoshiMines.Core.Models
{
    [DataContract]
    public class GuessResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "guess")]
        public int Guess { get; set; }

        [DataMember(Name = "outcome")]
        public string Outcome { get; set; }

        [DataMember(Name = "bombs")]
        public string Bombs { get; set; }

        [DataMember(Name = "random_string")]
        public string RandomString { get; set; }

        [DataMember(Name = "stake")]
        public double Stake { get; set; }

        [DataMember(Name = "next")]
        public double Next { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "change")]
        public double Change { get; set; }
    }
}                                                                                            