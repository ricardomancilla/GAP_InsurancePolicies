using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("Department")]
    public class DepartmentModel : BaseModel
    {
        [Key]
        public byte DepartmentID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public byte PhoneCode { get; set; }


        public virtual ICollection<CityModel> Cities { get; set; }
    }
}
