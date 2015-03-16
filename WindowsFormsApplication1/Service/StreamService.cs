using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IRECEClient.Service
{
    class StreamService
    {
        private static StreamService instance;

        private StreamService() { }

        public static StreamService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StreamService();
                }
                return instance;
            }
        }

        private Stream stm;

        public Stream Stm
        {
          get { return stm; }
          set { stm = value; }
        }

    }
}
