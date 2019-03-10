using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("Policy")]
    public class PolicyModel : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PolicyID { get; set; } = new Guid();

        [Required, StringLength(20, ErrorMessage = "Name accepts up to 20 characters")]
        public string Name { get; set; }

        [Required, StringLength(300, ErrorMessage = "Description accepts up to 300 characters")]
        public string Description { get; set; }

        public decimal CoveragePercentaje { get; set; }

        public byte Validity { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public short CoverageTypeID { get; set; }

        public short RiskTypeID { get; set; }

        public short PolicyStatusID { get; set; }


        [ForeignKey("CoverageTypeID")]
        public virtual CodeModel CoverageType { get; set; }

        [ForeignKey("RiskTypeID")]
        public virtual CodeModel RiskType { get; set; }

        [ForeignKey("PolicyStatusID")]
        public virtual CodeModel PolicyStatus { get; set; }

        public virtual ICollection<CustomerPolicyModel> CustomerPolicies { get; set; }
    }
}