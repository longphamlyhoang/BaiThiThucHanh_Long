using CakeManagements.Contexts;
using CakeManagements.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagements.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CakeManagementDBContext context;

        public CategoryService(CakeManagementDBContext context)
        {
            this.context = context;
        }

        public Category Get(int CategoryId)
        {
            return context.Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
        }

        public List<Category> Gets()
        {
            return context.Categories.Include(p => p.Cakes).ToList();
        }
    }
}
