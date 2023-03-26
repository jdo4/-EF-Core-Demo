using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products;
        }

        [HttpGet("{Id}")]
        public Product Get(int Id)
        {
            // return object or throw 404 error
            try
            {
                return context.Products.Find(Id);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        [HttpPut("{Id}")]
        public Product Put(int Id, [FromBody] Product product)
        {
            var existingProduct = context.Products.Find(Id);
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Image = product.Image;
            existingProduct.Price = product.Price;
            existingProduct.ShippingCost = product.ShippingCost;
            context.SaveChanges();
            return existingProduct;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var product = context.Products.Find(Id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
