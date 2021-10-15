using CakeManagements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagements.Services
{
    public interface ICategoryService
    {
        List<Category> Gets();
        Category Get(int CategoryId);

    }
}
