using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
    public class UpdateStocks
    {
        private AppDbContext _ctx;

        public UpdateStocks(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var stocks = new List<Stock>();
            foreach (var stock in stocks)
            {
                stocks.Add(new Stock
                {
                    Id = stock.Id,
                    Description = stock.Description,
                    ProductId = stock.ProductId,
                    Qty = stock.Qty
                });
            }
            _ctx.Stocks.UpdateRange(stocks);
            await _ctx.SaveChangesAsync();

            return new Response
            {
                Stock = request.Stock
            };
        }

        public class Request
        {

            public IEnumerable<StockViewModel> Stock { get; set; }
        }

        public class Response
        {
            public IEnumerable<StockViewModel> Stock { get; set; }

        }

        public class StockViewModel
        {
            public int Id { get; set; }

            public string Description { get; set; }

            public int Qty { get; set; }

            public int ProductId { get; set; }
        }


    }


}
