using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mail;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext context;

        public OrderController(AppDbContext context)
        {
            this.context = context;
        }


        private string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;

        }

        //[HttpGet]
        //public IEnumerable<Order> Get()
        //{
        //    return context.Orders;
        //}

        [HttpGet("{Id}")]
        public Order Get(int Id)
        {
            // return object or throw 404 error
            try
            {
                var order = context.Orders.Find(Id);
                order.Product = context.Products.Find(order.ProductId);
                return order;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        //find order by user id
        [HttpGet()]
        public IEnumerable<Order> GetOrderByUID([FromQuery] int userID)
        {
            // return object or throw 404 error
            try
            {
                 //var userID = int.Parse( HttpContext.Request.Query["user_id"]);
                var data = context.Orders.Where((o)=>o.UserID==userID);

                foreach(var d in data)
                {
                    d.Product = context.Products.Find(d.ProductId);
                }

                return data;
            }

            catch (Exception e)
            {
                return null;
            }

        }


        [HttpPost]
        public Order Post([FromBody] Order order)
        {
            order.CreatedAt = DateTime.Now;
            order.BillNo = GetRandomString();
            order.Status = 0;

            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        //[HttpPut("{id}")]
        //public Order Put(int id, [FromBody] Cart cart)
        //{
        //    var existingCartItem = context.Cart.Find(id);
        //    existingCartItem.Quantity = cart.Quantity;
        //    context.SaveChanges();
        //    return existingCartItem;
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    var cartItem = context.Cart.Find(id);
        //    context.Cart.Remove(cartItem);
        //    context.SaveChanges();
        //}
    }


    
}
