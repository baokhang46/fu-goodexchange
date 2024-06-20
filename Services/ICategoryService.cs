using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        void createCategory(Category category);
        void updateCategory(Category category);
        void deleteCategory(Category category);
        Category GetCategoryByName(string CategoryName);
        bool CategoryExist(int id);
    }
}
