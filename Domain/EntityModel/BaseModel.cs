using System;

namespace Domain.EntityModel
{
    public class BaseModel
    {
        public DateTime CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}
