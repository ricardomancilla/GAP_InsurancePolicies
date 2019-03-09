using System;

namespace Domain.EntityModel
{
    public class BaseModel
    {
        public DateTime CreateDtm { get; set; }

        public DateTime? LastUpdateDtm { get; set; }
    }
}
