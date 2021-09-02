using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
    public class UpdateProducts
    {
        private AppDbContext _appDbContext;
        public UpdateProducts(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Response> Do(Request vm)
        {
            var product = _appDbContext.Products.FirstOrDefault(x => x.Id == vm.id);
            product.Name = vm.Name;
            product.Description = vm.Description;
            product.Value = vm.Value;
            await _appDbContext.SaveChangesAsync();
            return new Response {
            Id = product.Id,
            Description = product.Description,
            Value = product.Value
            };
        }

        public class Request
        {
            public int id { get; set; }
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
