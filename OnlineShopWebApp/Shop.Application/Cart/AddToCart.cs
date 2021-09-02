using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Application.Cart
{
    public class AddToCart
    {
        private ISession _session;

        public AddToCart(ISession session )
        {
            _session = session;
        }
        
        public void Do(Request request)
        {
            var carList = new List<Domain.Models.Cart>();
            var strObj = _session.GetString("cart");
            
            if(!string.IsNullOrEmpty(strObj))
            {
                carList = JsonConvert.DeserializeObject<List<Domain.Models.Cart>>(strObj);
            } 
            if(carList.Any(x=> x.StockId == request.StockId))
            {
                carList.Find(x => x.StockId == request.StockId).Qty += request.Qty;
            }
            else
            {
                carList.Add(new Domain.Models.Cart
                {
                    StockId = request.StockId,
                    Qty = request.Qty
                });
            }

      
            strObj = JsonConvert.SerializeObject(carList);
            _session.SetString("cart", strObj);
        }

        public class Request
        {
            public int StockId { get; set; }

            public int Qty { get; set; }
        }
    }

   
}
