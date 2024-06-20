using BussinessObject.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        public void deleteCategory(Category category) => CategoryDAO.DeleteCategory(category);


        public List<Category> GetCategories() => CategoryDAO.GetCategories();

        public void createCategory(Category category) => CategoryDAO.CreateCategory(category);


        public void updateCategory(Category category) => CategoryDAO.UpdateCategory(category);

        public Category GetCategoryById(int id) => CategoryDAO.GetCategoryById(id);

        public Category GetCategoryByName(string CategoryName) => CategoryDAO.GetCategoryByName(CategoryName);

        public bool CategoryExist(int id) => CategoryDAO.CategoryExist(id);
    }
}
