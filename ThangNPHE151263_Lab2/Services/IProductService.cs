using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        void SaveProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(Product p);
        Product GetProdctById(int id);
    }
}
