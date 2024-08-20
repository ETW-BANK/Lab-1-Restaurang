using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        public DateTime BookingDate { get; set; }

       
        public int NumberOfGuests { get; set; } 

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }

        public int TableId { get; set; }

        [ForeignKey("TableId")]
        public Tables table { get; set; }  

        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public Menu menu { get; set; }




    }
}
