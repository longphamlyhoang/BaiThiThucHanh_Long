using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagements.Models.Cake
{
    public class Detail : Create
    {
        [Key]
        public int CakeId { get; set; }
    }
}
