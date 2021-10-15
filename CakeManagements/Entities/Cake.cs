using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CakeManagements.Entities
{
    public class Cake
    {
        [Key]
        public int CakeId { get; set; }
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
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
