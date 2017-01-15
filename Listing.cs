using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AuctionPOCOs
{
    [DataContract]
    public class Listing
    {
        [Key, DataMember]
        public int ListingId { get; set; }

        [DataMember, Required, MaxLength(100), Index(IsUnique = true)]
        public string ItemName { get; set; }

        [DataMember]
        public DateTime AuctionStartTime { get; set; }

        [DataMember]
        public DateTime AuctionEndTime { get; set; }

        [DataMember, Required]
        public decimal Price { get; set; }

        [DataMember, Required, MaxLength(500)]
        public string Description { get; set; }

        [DataMember, Required]
        public string ImageUrl { get; set; }

        [ForeignKey("Shipping"), DataMember]
        public int ShippingId { get; set; }
        public virtual Shipping Shipping { get; set; }

        [ForeignKey("Status"), DataMember]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        [ForeignKey("ProductCategory"), DataMember]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }

        [ForeignKey("User"), DataMember]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
