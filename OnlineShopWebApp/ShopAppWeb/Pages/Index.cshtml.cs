using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;
using Shop.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAppWeb.Pages
{
    public class IndexModel : PageModel
    {

        private AppDbContext _appDbContext;

        public IndexModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
       
       
        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
        public void OnGet()
        {
           Products =  new GetProducts(_appDbContext).Do();
        }
    
    }
}
