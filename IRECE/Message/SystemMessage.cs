using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRECE.Message
{
    class SystemMessage : Message
    {
        public new String Type
        {
            get
            {
                return "system";
            }
        }

        public String Word { get; set; }
    }
}
