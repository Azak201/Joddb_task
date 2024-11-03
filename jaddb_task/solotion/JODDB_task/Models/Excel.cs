using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace JODDB_task.Models;

public class Excel
{
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string UserEmail { get; set; }
        public decimal UserNumber { get; set;}
        public required string UserPassword { get; set; }
}
