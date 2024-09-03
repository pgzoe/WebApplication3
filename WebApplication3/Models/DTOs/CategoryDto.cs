using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models.EFModels;

namespace WebApplication3.Models.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }

    public static class CategoryExt
    {
        public static CategoryDto ToDto(this Category model)
        {
            return new CategoryDto
            {
                Id = model.Id,
                Name = model.Name,
                DisplayOrder = model.DisplayOrder,
            };
        }
    }

}