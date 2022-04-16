using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PH1_App
{
    class StatusOfPriviledge
    {
        private int oldState;
        private int newState;
        public void setOld(int number)
        {
            oldState = number;
        }
        public void setNew(int number)
        {
            newState = number;
        }
        public bool isChanged()
        {
            return oldState != newState;
        }
    }
}
