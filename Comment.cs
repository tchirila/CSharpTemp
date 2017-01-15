using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AuctionPOCOs
{
    [DataContract]
    public class Comment
    {
        [Key, DataMember]
        public int CommentId { get; set; }

        [DataMember, Required, MaxLength(100), Index(IsUnique = true)]
        public string Content { get; set; }

        [ForeignKey("Listing"), DataMember]
        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }

        [ForeignKey("User"), DataMember]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
