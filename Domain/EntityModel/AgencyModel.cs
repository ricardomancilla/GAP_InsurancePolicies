using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("Agency")]
    public class AgencyModel : BaseModel
    {
        [Key]
        public short AgencyID { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Address { get; set; }

        [StringLength(15), DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public int CityID { get; set; }


        [ForeignKey("CityID")]
        public virtual CityModel City { get; set; }
    }
}
