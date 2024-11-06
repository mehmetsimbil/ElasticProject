using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Product
{
    public class ProductListItemDto
    {
        public string ProductName { get; set; }
        public string ErpCode { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}
