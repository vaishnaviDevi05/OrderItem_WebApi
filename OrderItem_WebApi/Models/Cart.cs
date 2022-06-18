using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderItem_WebApi.Models
{
    public class Cart
    {
        [Key]
       
        public int Id { get; set; }

        public int UserId { get; set; }
        public int MenuItemId { get; set; }
       

        public string Name { get; set; }
    }
}
