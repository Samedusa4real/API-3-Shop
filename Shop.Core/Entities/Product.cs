using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int BrandId { get; set; }    
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public Brand Brand { get; set; }
    }
}
