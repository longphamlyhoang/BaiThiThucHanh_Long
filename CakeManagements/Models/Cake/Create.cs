using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagements.Models.Cake
{
    public class Create
    {
        [Required]
        public string CakeName { get; set; }
        [Required]
        public string Ingredient { get; set; }
        [Required]
        public string Expiry { get; set; }
        [Required]
        public string DateOfManufacture { get; set; }
        [Required]
        public int Price { get; set; }
        public bool Deleted { get; set; }
        public int CategoryId { get; set; }
        
    }
}
