using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Services
{
    public class MainControllerService : IMainControllerService
    {
        private readonly DataBaseContext DBContext = new DataBaseContext();

        public MainControllerService(DataBaseContext ctx)
        {
            DBContext = ctx;
        }

        public List<Product> StartingWithC()
        {
            var result = DBContext.Products.ToList().Where(x => x.ProductName.ToLower()[0] == 'c').ToList();
            return result;
        }

        public Product SelectCheapestProduct()
        {
            return DBContext.Products.ToList().OrderBy(x => x.Price).FirstOrDefault();
        }

        public double CostAllFromUSA()
        {
            double res = DBContext.Products.ToList()
                .Join(DBContext.Suppliers.ToList(),
                          x => x.SupplierID,
                          y => y.SupplierID,
                          (product, supplier) => new
                                                 {
                                                    product.Price,
                                                    supplier.Country
                                                 })
                .Where(x => x.Country.ToUpper() == "USA")
                .Select(x => x.Price)
                .Sum();
            return res;
        }

        public List<Supplier> CondimentsSuppliers()
        {
            var firstjoin = DBContext.Products.ToList()     //join products and suppliers => supplier + CategoryID
                .Join(DBContext.Suppliers.ToList(),
                          x => x.SupplierID,
                          y => y.SupplierID,
                          (product, supplier) => new
                          {
                              product.CategoryID,
                              supplier
                          }).ToList();
            var secondjoin = firstjoin                      //join result of firstjoin and categories => firstjoin + CategoryName
                .Join(DBContext.Categories.ToList(),
                          x => x.CategoryID,
                          y => y.CategoryID,
                          (two, category) => new
                          {
                              two,
                              category.CategoryName
                          }).ToList();
            var res = secondjoin.Where(x => x.CategoryName.ToUpper() == "CONDIMENTS")
                .Select(x => x.two.supplier)
                .Distinct()
                .ToList();
            return res;
        }

        public void Adder(string supplierName,
                            string supplierCity,
                            string supplierCountry,
                            string productName,
                            double productPrice,
                            string categoryName,
                            string categoryDescription)
        {
            Category category = new Category
            {
                CategoryName = categoryName,
                Description = categoryDescription
            };

            DBContext.Categories.Add(category);
            DBContext.SaveChanges();
            Supplier supplier = new Supplier
            {
                SupplierName = supplierName,
                City = supplierCity,
                Country = supplierCountry
            };
            DBContext.Suppliers.Add(supplier);
            DBContext.SaveChanges();
            
            Product product = new Product
            {
                SupplierID = supplier.SupplierID,
                ProductName = productName,
                Price = productPrice,
                CategoryID = category.CategoryID
            };
            DBContext.Products.Add(product);
            DBContext.SaveChanges();
        }
    }
}
