using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace JODDB_task.Models;

public class Users
{
        [Key]
        public int ID {get; set;}

        [StringLength(50)]
        public required string Name {get; set;}

        [Phone]
        public required string Number{get; set;}

        [DataType(DataType.Password)]
        public required string Password{get; set;}

        [EmailAddress]
        public required string Email{get; set;}

}
