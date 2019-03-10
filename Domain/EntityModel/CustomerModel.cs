using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("Customer")]
    public class CustomerModel : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CustomerID { get; set; } = new Guid();

        [StringLength(15)]
        public string Identification { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [StringLength(15), DataType(DataType.PhoneNumber)]
        public string HomePhoneNumber { get; set; }

        [Required, StringLength(50), DataType(DataType.PhoneNumber)]
        public string MobilePhoneNumber { get; set; }

        [Required, StringLength(100)]
        public string HomeAddress { get; set; }

        [Required, StringLength(80), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public int CityID { get; set; }


        [ForeignKey("CityID")]
        public CityModel City { get; set; }

        public ICollection<CustomerPolicyModel> CustomerPolicies { get; set; }
    }
}
