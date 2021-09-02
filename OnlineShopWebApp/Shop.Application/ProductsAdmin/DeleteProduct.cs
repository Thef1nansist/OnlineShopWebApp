using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.ProductsAdmin
{
   public class DeleteProduct
    {
        private AppDbContext _cnx;

        public DeleteProduct(AppDbContext cnx)
        {
            _cnx = cnx;
        }

        public async Task<bool> Do(int id)
        {
            var product = _cnx.Products.FirstOrDefault(x => x.Id == id);
           _cnx.Remove(product);
            await _cnx.SaveChangesAsync();
            return true;
        }
    }
}
