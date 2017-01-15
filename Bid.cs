using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AuctionPOCOs
{
    [DataContract]
    public class Bid
    {
        [Key, DataMember]
        public int BidId { get; set; }

        [DataMember, Required]
        public decimal BidAmount { get; set; }

        [ForeignKey("Listing"), DataMember]
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }

        [ForeignKey("User"), DataMember]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
