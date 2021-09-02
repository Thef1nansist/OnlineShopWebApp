using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
  public  class GetProduct
    {
        private AppDbContext _ctx;

        public GetProduct(AppDbContext ctx)
        {
            _ctx = ctx;

        }

        public ProductViewModel Do(string name) =>
            _ctx.Products
            .Include(x => x.Stock)
            .Where(x => x.Name == name)
            .Select(x => new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Value = $"${x.Value.ToString("N2")}",
                Stock = x.Stock.Select(t=> new StockViewModel
                {
                    Id = t.Id,
                    FlagInStock = t.Qty > 0,
                    Description = t.Description
                })
            })
            .FirstOrDefault();

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class StockViewModel
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public bool FlagInStock { get; set; }
        }
    }
}
