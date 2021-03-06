﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("Policy")]
    public class PolicyModel : BaseModel
    {
        [Key]
        public int PolicyID { get; set; }

        [Required, StringLength(20, ErrorMessage = "Name accepts up to 20 characters")]
        public string Name { get; set; }

        [Required, StringLength(300, ErrorMessage = "Description accepts up to 300 characters")]
        public string Description { get; set; }

        public decimal CoveragePercentage { get; set; }

        public byte CoverageTerm { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public short CoverageTypeID { get; set; }

        public short RiskTypeID { get; set; }

        public short PolicyStatusID { get; set; }

        [Column(Order = 12)]
        public DateTime? DeleteDate { get; set; }


        [ForeignKey("CoverageTypeID")]
        public CodeModel CoverageType { get; set; }

        [ForeignKey("RiskTypeID")]
        public CodeModel RiskType { get; set; }

        [ForeignKey("PolicyStatusID")]
        public CodeModel PolicyStatus { get; set; }

        public ICollection<CustomerPolicyModel> CustomerPolicies { get; set; }
    }
}