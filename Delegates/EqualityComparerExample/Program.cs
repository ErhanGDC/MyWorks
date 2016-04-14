using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityComparerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product> {
            new Product(){ ProductName="Product1", ProdutID=1, CategoryName="Category 1"},
            new Product(){ ProdutID=2, ProductName="Product2", CategoryName="Category 1"},
            new Product(){ ProdutID=3, ProductName="Product3", CategoryName="Category 2"},
            new Product(){ ProdutID=4, ProductName="Product4", CategoryName="Category 3"},
            new Product(){ ProdutID=5, ProductName="Product5", CategoryName="Category 4"},
            new Product(){ ProdutID=6, ProductName="Product6", CategoryName="Category 5"}};

            var result = products.Distinct(new ProductEqualityComparer());
            //var result = products.Distinct();

            foreach (var r in result)
            {
                Console.WriteLine(r.CategoryName);
            }
            Console.Read();
        }
    }

    public class Product
    { public int ProdutID { get; set; } public string ProductName { get; set; } public string CategoryName { get; set; } }

    public class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            //throw new NotImplementedException();
            return x.CategoryName.Equals(y.CategoryName);
        }

        public int GetHashCode(Product obj)
        {
            //throw new NotImplementedException();
            return obj.CategoryName.GetHashCode();
        }
    }
}
