using BussinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
		private static CategoryDAO instance = null;

		public CategoryDAO()
		{
		}



		public static CategoryDAO Instance
		{

			get
			{
				if (instance == null)
				{
					instance = new CategoryDAO();
				}
				return instance;
			}

		}
		public List<Category> GetCategories()
		{
			var dBContext = new FugoodexchangeContext();

			return dBContext.Categories.ToList();
		}

		public Category GetCategory(int cate)
		{
			try
			{
				var dbContent = new FugoodexchangeContext();
				return dbContent.Categories.SingleOrDefault(m => m.CategoryId.Equals(cate));
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AddCategory(Category cate)
		{
			try
			{
				var dbContent = new FugoodexchangeContext();
				Category category = GetCategory(cate.CategoryId);
				if (category != null)
				{
					throw new Exception("CategoryId has existed!");
				}

				dbContent.Categories.Add(cate);
				dbContent.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public void UpdateCategory(Category cate)
		{
			try
			{
				using (var dbContent = new FugoodexchangeContext())
				{
					var existingAccount = dbContent.Categories.SingleOrDefault(a => a.CategoryId == cate.CategoryId);

					if (existingAccount != null)
					{
						existingAccount.CategoryId = cate.CategoryId;
						existingAccount.CategoryName = cate.CategoryName;
						dbContent.Categories.Update(existingAccount);
						dbContent.SaveChanges();

					}
					else
					{
						throw new Exception("CategoryID hasn't existed!");
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void DeleteCategory(int cate)
		{
			try
			{
				var dbContent = new FugoodexchangeContext();
				Category cateList = GetCategory(cate);
				if (cate != null)
				{
					dbContent.Categories.Remove(cateList);
					dbContent.SaveChanges();
				}

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		/*public static Category GetCategoryById(int CategoryId)
        {
            using var db = new FugoodexchangeContext();
            return db.Categories.FirstOrDefault(c => c.CategoryId.Equals(CategoryId));
        }

        public static Category GetCategoryByName(string CategoryName)
        {
            using var db = new FugoodexchangeContext();
            return db.Categories.FirstOrDefault(c => c.CategoryName.Equals(CategoryName));
        }

        public static bool CategoryExist(int id)
        {
            using var _context = new FugoodexchangeContext();
            return _context.Categories.Any(a => a.CategoryId.Equals(id));
        }*/
    }
}
