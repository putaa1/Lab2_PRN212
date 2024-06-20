using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICatergoryService
    {
        private readonly ICatergoryRepository iCatergoryRepository;
        public CategoryService()
        {
            iCatergoryRepository = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return iCatergoryRepository.GetCategories();
        }
    }
}
