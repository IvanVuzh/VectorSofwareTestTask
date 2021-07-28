using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ProductName { get; set; }

        [Required]
        [ForeignKey("SupplierID")]
        public int SupplierID { get; set; }

        [Required]
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }
}
