using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public interface IEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
