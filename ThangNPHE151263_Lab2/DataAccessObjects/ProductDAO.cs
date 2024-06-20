using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var myContextDB = new MyStoreContext();
            return myContextDB.Products.ToList();
        }
        public static void SaveProduct(Product p)
        {
            var myContextDB = new MyStoreContext();
            myContextDB.Products.Add(p);
            myContextDB.SaveChanges();
        }
        public static void UpdateProduct(Product p)
        {
            var myContextDB = new MyStoreContext();
            myContextDB.Entry(p).State = EntityState.Modified;
            myContextDB.SaveChanges();
        }
        public static void DeleteProduct(Product p)
        {
            var myContextDB = new MyStoreContext();
            myContextDB.Products.Remove(p);
            myContextDB.SaveChanges();
        }
        public static Product GetProdctById(int id)
        {
            var myContextDB = new MyStoreContext();
            return myContextDB.Products.FirstOrDefault(i => i.ProductId.Equals(id));
        }
    }
}
