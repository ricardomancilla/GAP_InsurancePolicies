using System;

namespace Domain.ViewModel
{
    public class CustomerVM
    {
        public Guid CustomerID { get; set; } = new Guid();

        public string Identification { get; set; }

        public string Name { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
