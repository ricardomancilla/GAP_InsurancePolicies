﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntityModel
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(80), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(100), DataType(DataType.Password)]
        public string Password { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}