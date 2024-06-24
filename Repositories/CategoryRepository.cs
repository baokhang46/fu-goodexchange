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
		public void AddCategory(Category cate) => CategoryDAO.Instance.AddCategory(cate);


		public void DeleteCategory(int cate) => CategoryDAO.Instance.DeleteCategory(cate);


		public List<Category> GetCategories() => CategoryDAO.Instance.GetCategories();


		public Category GetCategory(int cate) => CategoryDAO.Instance.GetCategory(cate);


		public void UpdateCategory(Category cate) => CategoryDAO.Instance.UpdateCategory(cate);
	}
}
