using System;
using System.Collections;

namespace Image_Steganography
{
    class Tools
    {
        static public int GetBit(int value, int i)
        {
            if ((value & (1 << i)) != 0)
                return 1;

            return 0;
        }

        static public int ClearBit(int value, int i)
        {
            value = value & (value ^ (1 << i));
            return value;
        }

        static public byte ClearBit(byte value, int i)
        {
            var x = value ^ (byte)(1 << i);
            value &= (byte)x;
            return value;
        }

        static public int SetBit(int value, int i)
        {
            value = ClearBit(value, i);
            value |= (1 << i);
            return value;
        }

        static public byte SetBit(byte value, int i)
        {
            value = ClearBit(value, i);
            value |= (byte)(1 << i);
            return value;
        }

        static public int SetBitValue(int value, int i, int x)
        {
            if (x != 0)
                value = SetBit(value, i);
            else
                value = ClearBit(value, i);

            return value;
        }

        static public byte SetBitValue(byte value, int i, int x)
        {
            if (x != 0)
                value = SetBit(value, i);
            else
                value = ClearBit(value, i);

            return value;
        }

        static public BitArray ConvertBytesToBits(byte []byteArr)
        {
            BitArray bitArray = new BitArray(byteArr.Length * 8);

            for(int i = 0; i < byteArr.Length; i ++)
            {
                for(int j = 0; j < 8; j ++)
                {
                    int x = GetBit(byteArr[i], j);

                    if (x == 0)
                        bitArray[i * 8 + j] = false;
                    else
                        bitArray[i * 8 + j] = true;
                }
            }

            return bitArray;
        }

        static public BitArray ConvertStringToBits(string str)
        {
            BitArray bitArray = new BitArray(str.Length * 8);

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int x = GetBit(str[i], j);

                    if (x == 0)
                        bitArray[i * 8 + j] = false;
                    else
                        bitArray[i * 8 + j] = true;
                }
            }

            return bitArray;
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
