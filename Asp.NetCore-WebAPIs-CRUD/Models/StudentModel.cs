using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestfulAPIs_Asp.netCore.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentID { get; set; }
        [Required]
        public string RegistrationNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
