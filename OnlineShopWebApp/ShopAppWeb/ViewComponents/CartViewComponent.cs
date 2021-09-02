using Microsoft.AspNetCore.Mvc;
using Shop.Application.Cart;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppWeb.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private AppDbContext _ctx;

        public CartViewComponent(AppDbContext ctx)
        {
            _ctx = ctx;

        }

        public IViewComponentResult Invoke(string view = "Default")
        {
            return View(view,new GetCart(HttpContext.Session, _ctx).Do());
        }
    }
}
