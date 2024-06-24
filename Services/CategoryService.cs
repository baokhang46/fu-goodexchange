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
		private ICategoryRepository categoryRepository = null;

		public CategoryService()
		{
			categoryRepository = new CategoryRepository();
		}
		public void AddCategory(Category cate)
		{
			categoryRepository.AddCategory(cate);
		}

		public void DeleteCategory(int cate)
		{
			categoryRepository.DeleteCategory(cate);
		}

		public List<Category> GetCategories()
		{
			return categoryRepository.GetCategories();
		}

		public Category GetCategory(int cate)
		{
			return categoryRepository.GetCategory(cate);
		}

		public void UpdateCategory(Category cate)
		{
			categoryRepository.UpdateCategory(cate);
		}
	}
}
