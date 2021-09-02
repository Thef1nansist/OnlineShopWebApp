using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace Shop.Application.Cart
{
   public class GetCart
    {
        private ISession _session;
        private AppDbContext _ctx;

        public GetCart(ISession session, AppDbContext ctx)
        {
            _session = session;
            _ctx = ctx;
        }

        public IEnumerable<Response>  Do()
        {
            var strObj = _session.GetString("cart");
            if (string.IsNullOrEmpty(strObj))
            {
                return new List<Response>();
            }

            var cartList = JsonConvert.DeserializeObject<List<Domain.Models.Cart>>(strObj);

            var test = _ctx.Stocks.Select(x => x.Product).ToList();

            var resp = _ctx.Stocks
                   .Include(x => x.Product)
                    .AsEnumerable()
                   .Where(x => cartList.Any(y => y.StockId == x.Id))
                   .Select(x => new Response
                   {
                       Name = x.Product.Name,
                       Value = $"${x.Product.Value.ToString("N2")}",
                       StockId = x.Id,
                       Qty = cartList.FirstOrDefault(y => y.StockId == x.Id).Qty
                   })
                   .ToList();
            return resp;
        }

        public class Response
        {
            public string Name { get; set; }

            public string Value { get; set; }
            public int StockId { get; set; }

            public int Qty { get; set; }
        }
    }
}

