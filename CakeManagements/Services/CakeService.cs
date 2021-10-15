using CakeManagements.Contexts;
using CakeManagements.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagements.Services
{
    public class CakeService : ICakeService
    {
        private readonly CakeManagementDBContext context;

        public CakeService(CakeManagementDBContext context)
        {
            this.context = context;
        }

        public bool CreateCake(Cake model)
        {
            try
            {
                context.Add(model);
                return context.SaveChanges() > 0;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool DetailCake(Cake model)
        {
            throw new NotImplementedException();
        }

        public bool EditCake(Cake cake)
        {
            try
            {
                context.Attach(cake);
                return context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public Cake Get(int cakeId)
        {
            return context.Cakes.Include(p => p.Category).FirstOrDefault(p => p.CakeId == cakeId);
        }

        public List<Cake> GetCakeByCategory(int categoryId)
        {
            return context.Cakes.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToList();
        }

        public bool RemoveCake(Cake model)
        {
            throw new NotImplementedException();
        }
    }
}
