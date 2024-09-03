using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DTOs;
using WebApplication3.Models.EFModels;

namespace WebApplication3.Models.Repositories
{
    public class CategoryRepository
    {
        AppDbContext db = new AppDbContext();

        internal void Create(CategoryDto dto)
        {
            var entity = new Category() { Name = dto.Name, DisplayOrder = dto.DisplayOrder};
            db.Categories.Add(entity);
            db.SaveChanges();
        }

        internal bool IsExistName(string name)
        {
            var entity = db.Categories.FirstOrDefault(c => c.Name == name);

            return entity != null;
        }
    }
}