using BussinessObject.Model;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
		List<Category> GetCategories();
		void AddCategory(Category cate);

		Category GetCategory(int cate);

		void DeleteCategory(int cate);

		void UpdateCategory(Category cate);
	}
}
