using System;
using System.Collections;

namespace Image_Steganography
{
    class Tools
    {
        // O(1)
        static public int GetBit(int value, int i)// O(1)
        {
            if ((value & (1 << i)) != 0)// O(1)
                return 1;// O(1)

            return 0;// O(1)
        }
        // O(1)
        static public int ClearBit(int value, int i)// O(1)
        {
            value = value & (value ^ (1 << i));// O(1)
            return value;// O(1)
        }
        // O(1)
        static public byte ClearBit(byte value, int i)// O(1)
        {
            var x = value ^ (byte)(1 << i);// O(1)
            value &= (byte)x;// O(1)
            return value;// O(1)
        }

        static public int SetBit(int value, int i)// O(1)
        {
            value = ClearBit(value, i);// O(1)
            value |= (1 << i);// O(1)
            return value;// O(1)
        }

        static public byte SetBit(byte value, int i)// O(1)
        {
            value = ClearBit(value, i);// O(1)
            value |= (byte)(1 << i);// O(1)
            return value;// O(1)
        }

        static public int SetBitValue(int value, int i, int x)// O(1)
        {
            if (x != 0)// O(1)
                value = SetBit(value, i);// O(1)
            else
                value = ClearBit(value, i);// O(1)

            return value;// O(1)
        }

        static public byte SetBitValue(byte value, int i, int x)
        {
            if (x != 0)// O(1)
                value = SetBit(value, i);// O(1)
            else// O(1)
                value = ClearBit(value, i);// O(1)

            return value;// O(1)
        }

        static public BitArray ConvertBytesToBits(byte []byteArr)
        {
            BitArray bitArray = new BitArray(byteArr.Length * 8);// O(N)
            // O(N)
            for (int i = 0; i < byteArr.Length; i ++)// O(1)
            {
                for(int j = 0; j < 8; j ++)// O(1)
                {
                    int x = GetBit(byteArr[i], j);// O(1)

                    if (x == 0)// O(1)
                        bitArray[i * 8 + j] = false;// O(1)
                    else
                        bitArray[i * 8 + j] = true;// O(1)
                }
            }

            return bitArray;
        }

        static public BitArray ConvertStringToBits(string str)
        {
            BitArray bitArray = new BitArray(str.Length * 8);// O(N)
            // O(N)
            for (int i = 0; i < str.Length; i++)// O(1)
            {
                for (int j = 0; j < 8; j++)// O(1)
                {
                    int x = GetBit(str[i], j);// O(1)

                    if (x == 0)// O(1)
                        bitArray[i * 8 + j] = false;// O(1)
                    else
                        bitArray[i * 8 + j] = true;// O(1)
                }
            }

            return bitArray;// O(1)
        }

        static public BitArray ConvertIntToBits(int num)
        {
            BitArray bitArray = new BitArray(32);  // integer size
            
            for(int i = 0; i < 32; i ++)
            {
                int x = GetBit(num, i);

                if (x == 0)
                    bitArray[i] = false;
                else
                    bitArray[i] = true;
            }

            return bitArray;
        }

        static public int ConvertBitsToInt(BitArray bitArray)
        {
            int ret = 0;

            for(int i = 0; i < bitArray.Length; i ++)
            {
                int x;

                if (bitArray[i])
                    x = 1;
                else
                    x = 0;

                ret = SetBitValue(ret, i, x);
            }

            return ret;
        }

    }
}
