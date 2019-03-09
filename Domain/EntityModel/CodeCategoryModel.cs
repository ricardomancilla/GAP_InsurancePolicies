using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("CodeCategory")]
    public class CodeCategoryModel : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short CodeCategoryID { get; set; }

        [Required, StringLength(20)]
        public string Code { get; set; }

        [Required, StringLength(300)]
        public string Description { get; set; }


        public virtual ICollection<CodeModel> Codes { get; set; }
    }
}
