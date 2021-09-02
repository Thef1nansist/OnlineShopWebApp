using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Cart
{
   public class GetCustomerInformation
    {

        private ISession _session;

        public GetCustomerInformation(ISession session)
        {
            _session = session;
        }

        public Request Do()
        {

           var strObj = _session.GetString("customer-info");
            
            if(String.IsNullOrEmpty(strObj))
            {
                return null;
            }    

            var response = JsonConvert.DeserializeObject<Request>(strObj);

            return response;
           
        }

        public class Request
        {
            
            public string FirstName { get; set; }

            public string LastName { get; set; }
            public string Email { get; set; }

            public string PhoneNumber { get; set; }

            public string Address1 { get; set; }

            public string Adress2 { get; set; }

            public string City { get; set; }

            public string PostCode { get; set; }
        }
    }
}
