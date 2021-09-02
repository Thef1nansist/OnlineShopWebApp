using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
using Shop.Application.Products;
using Shop.Database;


namespace ShopAppWeb.Pages
{
    public class ProductModel : PageModel
    {
        private AppDbContext _ctx;
        public GetProduct.ProductViewModel Product { get; set; }

        public ProductModel(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        [BindProperty]
        public AddToCart.Request CartVM { get; set; }


        public IActionResult OnGet(string name)
        {
            Product = new GetProduct(_ctx).Do(name.Replace("-", " "));
            if (Product == null) {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            new AddToCart(HttpContext.Session).Do(CartVM);

            return RedirectToPage("Cart");
        }
    }

    
}
