using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("CustomerPolicy")]
    public class CustomerPolicyModel : BaseModel
    {
        [Key]
        public int CustomerPolicyID { get; set; }

        public int CustomerID { get; set; }

        public int PolicyID { get; set; }

        public DateTime EffectiveStartDate { get; set; }

        public DateTime DueDate { get; set; }

        public short StatusID { get; set; }


        [ForeignKey("CustomerID")]
        public CustomerModel Customer { get; set; }

        [ForeignKey("PolicyID")]
        public PolicyModel Policy { get; set; }

        [ForeignKey("StatusID")]
        public CodeModel Status { get; set; }
    }
}
