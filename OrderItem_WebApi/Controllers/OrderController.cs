﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderItem_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrderItem_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromQuery]int id)
        {

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:49044/api/");
                var responseTask = client.GetAsync("MenuItem");
                responseTask.Wait();
                var result = responseTask.Result;
                List<Cart> Items = new List<Cart>();

                if (result.IsSuccessStatusCode)
                {

                    string jsonData = result.Content.ReadAsStringAsync().Result;


                    Items = JsonConvert.DeserializeObject<List<Cart>>(jsonData);
                    Cart c = Items.SingleOrDefault(item => item.Id == id);

                    c.MenuItemId = 1;
                    c.UserId = 1;


                    return Ok(c);

                }
                else
                {

                    return BadRequest();

                }

            };
        }


    }
   
}
