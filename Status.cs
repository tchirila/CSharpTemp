using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AuctionPOCOs
{
    [DataContract]
    public class Status
    {
        [Key, DataMember]
        public int StatusId { get; set; }

        [DataMember, Required, MaxLength(50), Index(IsUnique = true)]
        public string status { get; set; }
    }
}
