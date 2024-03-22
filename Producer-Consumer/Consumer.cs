using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer_Consumer
{
    class Consumer
    {
        private int state { get; set; }
        private int currentPos { get; set; }

        public Consumer()
        {
            state = 0;
            currentPos = 0;
        }
        public bool Consume()
        {
            return false;
        }

    }
}
