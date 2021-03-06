using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Cart
{
   public class AddCustomerInformation
    {

        private ISession _session;

        public AddCustomerInformation(ISession session)
        {
            _session = session;
        }

        public void Do(Request request)
        {
           

          var strObj = JsonConvert.SerializeObject(request);
            _session.SetString("customer-info", strObj);
        }

        public class Request
        {
            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }

            [Required]
            public string Address1 { get; set; }
            public string Adress2 { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public string PostCode { get; set; }
        }
    }
}
