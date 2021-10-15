using CakeManagements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagements.Services
{
    public interface ICakeService
    {
        List<Cake> GetCakeByCategory(int categoryId);
        bool CreateCake(Cake model);
        bool EditCake(Cake model);
        bool RemoveCake(Cake model);
        bool DetailCake(Cake model);
        Cake Get(int cakeId);
    }
}
