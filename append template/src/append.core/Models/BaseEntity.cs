using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime Updatedate { get; set; }
    }
}
