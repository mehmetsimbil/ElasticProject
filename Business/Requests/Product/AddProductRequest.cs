using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Product
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public string ErpCode { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}
