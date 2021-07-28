using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string CategoryName { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
    }
}
