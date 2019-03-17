using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class CustomerPolicyVM
    {
        public int? CustomerPolicyID { get; set; }

        public int? CustomerID { get; set; }

        public string Customer { get; set; }

        public int? PolicyID { get; set; }

        public string Policy { get; set; }

        public DateTime? EffectiveStartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public short? StatusID { get; set; }
    }
}
