using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.DTOs;
using WebApplication3.Models.Repositories;

namespace WebApplication3.Models.Services
{
    public class CategoryService
    {
        internal void Create(CategoryDto dto)
        {
            var repo = new CategoryRepository();

            if (repo.IsExistName(dto.Name))
            {
                //判斷dto.Name是否唯一
                throw new Exception("分類名稱已存在");
            }
            //叫用 repo.create
            repo.Create(dto);
        }
    }
}