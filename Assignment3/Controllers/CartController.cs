using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext context;

        public CartController(AppDbContext context)
        {
            this.context = context;
        }



        //[HttpGet]
        //public IEnumerable<Cart> Get()
        //{
        //    return context.Cart;
        //}



        //[HttpGet("{id}")]
        //public Cart Get(int id)
        //{
        //    // return object or throw 404 error
        //    try
        //    {
        //        return context.Cart.Find(id);
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }

        //}


        //find cart by user id
        [HttpGet()]
        public IEnumerable<Cart> GetOrderByUID([FromQuery] int userID)
        {
            // return object or throw 404 error
            try
            {
                //var userID = int.Parse( HttpContext.Request.Query["user_id"]);
                var data = context.Cart.Where((c) => c.UserID == userID);
                foreach (var d in data)
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
        public Cart Post([FromBody] Cart cart)
        {
            cart.Product  = context.Products.Find(cart.ProductId);
            context.Cart.Add(cart);
            context.SaveChanges();
            return cart;
        }

        [HttpPut("{Id}")]
        public Cart Put(int Id, [FromBody] Cart cart)
        {
            var existingCartItem = context.Cart.Find(Id);
            existingCartItem.Quantity = cart.Quantity;
            context.SaveChanges();
            return existingCartItem;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var cartItem = context.Cart.Find(Id);
            context.Cart.Remove(cartItem);
            context.SaveChanges();
        }
    }
}
