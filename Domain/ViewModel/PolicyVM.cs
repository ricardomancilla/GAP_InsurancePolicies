using System;

namespace Domain.ViewModel
{
    public class PolicyVM
    {
        public int PolicyID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal CoveragePercentage { get; set; }

        public byte CoverageTerm { get; set; }

        public decimal Price { get; set; }

        public short CoverageTypeID { get; set; }

        public string CoverageType { get; set; }

        public short RiskTypeID { get; set; }

        public string RiskType { get; set; }
    }
}