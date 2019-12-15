using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Steganography
{
    class Bit
    {
        private bool value;

        public void Set()
        {
            value = true;
        }
        public void Clear()
        {
            value = false;
        }

        public void SetValue(int i)
        {
            value = (i != 0);
        }
        public int GetBit()
        {
            if (value)
                return 1;

            return 0;
        }
        
    }
}
