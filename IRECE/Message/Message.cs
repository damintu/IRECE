using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRECE.Message
{
    public abstract class Message
    {
        public string Type { get { return ""; } }
        public string Text { get; set; }

        public String ToString()
        {
            return "";
        }
    }
}
