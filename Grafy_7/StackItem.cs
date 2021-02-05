using System;
using System.Collections.Generic;
using System.Text;

namespace Grafy_7
{
    class StackItem
    {
        public int startIndex;
        public int repeat;
        public int repeatNow;

        public StackItem(int index)
        {
            this.startIndex = index;
            this.repeat = 0;
            this.repeatNow = 0;
        }
    }
}