using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Cart;
using Shop.Database;

namespace ShopAppWeb.Pages
{
    public class CartModel : PageModel
    {
        private AppDbContext _ctx;

        public IEnumerable< GetCart.Response> Cart { get; set; }
        public CartModel(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult OnGet()
        {
            Cart = new GetCart(HttpContext.Session, _ctx).Do();
            return Page();
        }
    }
}
