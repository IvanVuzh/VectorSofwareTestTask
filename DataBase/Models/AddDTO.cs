using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class AddDTO
    {
        public string SupplierName { get; set; }
        public string SupplierCity { get; set; }
        public string SupplierCountry { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
