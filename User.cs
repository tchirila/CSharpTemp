using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AuctionPOCOs
{
    [DataContract]
    public class User
    {
        [Key, DataMember]
        public int UserId { get; set; }

        [DataMember, Required, MaxLength(100), Index(IsUnique = true)]
        public string Username { get; set; }

        [DataMember, Required, MaxLength(100), Index(IsUnique = true)]
        public string EmailAddress { get; set; }

        [DataMember, Required]
        public string Password { get; set; }

        [DataMember, Required]
        public string Address { get; set; }
    }
}
