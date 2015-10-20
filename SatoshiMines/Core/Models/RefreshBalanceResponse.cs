using System.Runtime.Serialization;    

namespace SatoshiMines.Core.Models
{
    [DataContract]
    public class RefreshBalanceResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "balance")]
        public double Balance { get; set; }  
    }
}