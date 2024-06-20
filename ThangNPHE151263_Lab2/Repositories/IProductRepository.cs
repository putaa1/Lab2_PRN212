using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
            => ProductDAO.GetProducts();
        public void SaveProduct(Product p)
            => ProductDAO.SaveProduct(p);

        public void DeleteProduct(Product p)
            => ProductDAO.DeleteProduct(p);

        public void UpdateProduct(Product p)
            => ProductDAO.UpdateProduct(p);
        public Product GetProdctById(int id)
            => ProductDAO.GetProdctById(id);
    }
}
