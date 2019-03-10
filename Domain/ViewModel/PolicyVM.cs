using System;

namespace Domain.ViewModel
{
    public class PolicyVM
    {
        public Guid PolicyID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal CoveragePercentaje { get; set; }

        public byte Validity { get; set; }

        public decimal Price { get; set; }

        public string CoverageType { get; set; }

        public string RiskType { get; set; }

        public short PolicyStatusID { get; set; }
    }
}