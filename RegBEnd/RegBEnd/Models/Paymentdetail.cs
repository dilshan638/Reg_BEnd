using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegBEnd.Models
{
    public class Paymentdetail
    {

        [Key]
        public int NIC { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]

        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]

        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(16)")]

        public string Date { get; set; }
        [Required]
        [Column(TypeName = "varchar(3)")]

        public string Distric { get; set; }



    }
}
