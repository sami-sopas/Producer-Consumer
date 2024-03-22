using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer_Consumer.Classes
{
    class Producer
    {
        private int state { get; set; }
        private int currentPos { get; set; }

        public Producer()
        {
            state = 0;
            currentPos = 0;
        }

        public bool Produce()
        {
            return true;
        }

        public void setState(int value)
        {
            state = value;
        }

        public int getState()
        {
            return state;
        }

        public void setCurrentPos(int value)
        {
            currentPos = value;
        }

        public int getCurrentPos()
        {
            return currentPos;
        }
    }
}
