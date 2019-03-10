using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("City")]
    public class CityModel : BaseModel
    {
        [Key]
        public int CityID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public byte DepartmentID { get; set; }


        [ForeignKey("DepartmentID")]
        public DepartmentModel Department { get; set; }
    }
}
