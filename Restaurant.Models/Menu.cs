using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Menu
    {

  
        public int Id { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; } 

        public double Price { get; set; }   

        public bool IsAvailable { get; set; }   

        public string? ImageUrl { get; set; }    

      
    }
}
