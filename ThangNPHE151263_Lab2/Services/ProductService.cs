using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iProductRepository;
        public ProductService()
        {
            iProductRepository = new ProductRepository();
        }

        public List<Product> GetProducts()
        {
            return iProductRepository.GetProducts();
        }

        public void SaveProduct(Product p)
        {
            iProductRepository.SaveProduct(p);
        }

        public Product GetProdctById(int id)
        {
            return iProductRepository.GetProdctById(id);
        }
        public void UpdateProduct(Product p)
        {
            iProductRepository.UpdateProduct(p);
        }
        public void DeleteProduct(Product p)
        {
            iProductRepository.DeleteProduct(p);
        }
    }
}
