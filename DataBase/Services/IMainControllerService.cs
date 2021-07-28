using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Services
{
    public interface IMainControllerService
    {
        public List<Product> StartingWithC();

        public Product SelectCheapestProduct();

        public double CostAllFromUSA();

        public List<Supplier> CondimentsSuppliers();

        public void Adder(string supplierName,
                            string supplierCity,
                            string supplierCountry,
                            string productName,
                            double productPrice,
                            string categoryName,
                            string categoryDescription);
    }
}
