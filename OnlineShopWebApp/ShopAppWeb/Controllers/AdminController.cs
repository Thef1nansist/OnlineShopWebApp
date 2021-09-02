using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Application.StockAdmin;
using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppWeb.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private AppDbContext _ctx;

        public AdminController(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("products")]
        public IActionResult GetProducts() => Ok(new GetProducts(_ctx).Do());

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct.Request req) => Ok((await new CreateProduct(_ctx).Do(req)));

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) => Ok( (await new DeleteProduct(_ctx).Do(id)));
        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProducts.Request req) => Ok((await new UpdateProducts(_ctx).Do(req))); 
        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id) => Ok(new GetProduct(_ctx).Do(id));


        //Stock
        [HttpGet("stocks")]
        public IActionResult GetStocks() => Ok(new GetStock(_ctx).Do());

        [HttpPost("stocks")]
        public async Task<IActionResult> CreateStocks([FromBody] CreateStock.Request req) => Ok((await new CreateStock(_ctx).Do(req)));

        [HttpDelete("stocks/{id}")]
        public async Task<IActionResult> DeleteStocks(int id) => Ok((await new DeleteStock(_ctx).Do(id)));
        [HttpPut("stocks")]
        public async Task<IActionResult> UpdateStocks([FromBody] UpdateStocks.Request req) => Ok((await new UpdateStocks(_ctx).Do(req)));
   
    }
}
