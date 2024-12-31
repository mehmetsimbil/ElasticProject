using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Product
{
    public class AddProductResponse
    {
        public AddProductResponse(int id, string productName, DateTime createdTime)
        {
            Id = id;
            ProductName = productName;
            CreatedTime = createdTime;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
