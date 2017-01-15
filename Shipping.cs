using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AuctionPOCOs
{
    [DataContract]
    public class Shipping
    {
        [Key, DataMember]
        public int ShippingId { get; set; }

        [DataMember, Required, MaxLength(50), Index(IsUnique = true)]
        public string ShipMode { get; set; }
    }
}
