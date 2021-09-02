using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.StockAdmin
{
   public class DeleteStock
    {
        private AppDbContext _ctx;

        public DeleteStock(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var stock = _ctx.Stocks.FirstOrDefault(x => x.Id == id);
            _ctx.Remove(stock);
            await _ctx.SaveChangesAsync();

            return true;
        }

       
    }
}
