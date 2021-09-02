using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Application.ProductsAdmin
{
    public class CreateProduct
    {
        private AppDbContext _appDbContext;
        public CreateProduct(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Response> Do(Request request)
        {
          var product = new Product
            {
                Name = request.Name,
                Description = request.Description, 
                Value = request.Value
            };
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
            return new Response
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value
            };
        }

        public class Request
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
