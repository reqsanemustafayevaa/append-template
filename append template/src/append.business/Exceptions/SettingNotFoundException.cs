using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace append.business.Exceptions
{
    public class SettingNotFoundException:Exception
    {
        public string PropertyName { get; set; }
        public SettingNotFoundException()
        {

        }
        public SettingNotFoundException(string? message) : base(message)
        {

        }
        public SettingNotFoundException(string propertyname, string? message) : base(message)
        {
            PropertyName = propertyname;
        }
    }
}
