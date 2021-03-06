﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("Code")]
    public class CodeModel : BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short CodeID { get; set; }

        [Required, StringLength(20)]
        public string Code { get; set; }

        [Required, StringLength(300)]
        public string Description { get; set; }

        public short CodeCategoryID { get; set; }


        [ForeignKey("CodeCategoryID")]
        public CodeCategoryModel CodeCategory { get; set; }
    }
}
