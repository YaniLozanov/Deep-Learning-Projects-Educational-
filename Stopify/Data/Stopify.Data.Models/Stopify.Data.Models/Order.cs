using System;
using System.Collections.Generic;
using System.Text;

namespace Stopify.Data.Models
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime IssuedOn { get; set; }
        public int Quantity { get; set; }
        public int MyProperty { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public string IssuerId { get; set; }
        public StopifyUser Issuer { get; set; }

        public int StatusId { get; set; }
        public OrderStatus  Status { get; set; }




    }
}
