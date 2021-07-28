using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string SupplierName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string City{ get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Country { get; set; }
    }
}
