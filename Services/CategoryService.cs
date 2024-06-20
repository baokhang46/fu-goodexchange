using BussinessObject.Model;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void createCategory(Category category)
        {
             _categoryRepository.createCategory(category);
        }

        public void deleteCategory(Category category)
        {
            _categoryRepository.deleteCategory(category);
        }

        public List<Category> GetCategories()
        {
           return _categoryRepository.GetCategories();
        }

        public Category GetCategoryById(int id)
        {
           return _categoryRepository.GetCategoryById(id);
        }

        public Category GetCategoryByName(string CategoryName)
        {
            return _categoryRepository.GetCategoryByName(CategoryName);
        }

        public void updateCategory(Category category)
        {
            _categoryRepository.updateCategory(category);
        }

        public bool CategoryExist(int id)
        {
            return _categoryRepository.CategoryExist(id);
        }
    }
}
