using System.Collections;
using System.Collections.Generic;
using static Image_Steganography.Tools;

namespace Image_Steganography
{
    class StegoImage : Image
    {
        private int h, w, dataSize, fileTypeCode;
        private Hamiltonian hamiltonian;
        private BitArray data;
        private void GetMetaData()
        {
            int c = 0;
            dataSize = h = w = 0;
            // extrating block height
            for (int i = 0; i < blockBits; i++, c++)
            {
                h |= ((red[i] & 1) << c);
            }

            c = 0;
            // extracting block width
            for (int i = blockBits; i < 2 * blockBits; i++, c++)
            {
                w |= ((red[i] & 1) << c);
            }

            c = 0;
            // extracting data Size
            for(int i = 2 * blockBits; i < 2 * blockBits + dataBits; i ++, c++)
            {
                dataSize |= ((red[i] & 1) << c);
            }

            c = 0;
            // extracting code of file Type 
            for (int i = dataOverHead - fileTypeBits; i < dataOverHead; i++, c++)
            {
                fileTypeCode |= ((red[i] & 1) << c);
            }
        }

        private int ExtractPathCode(int []subPixel)
        {
            int pathCode = 0;

            for(int i = 0; i < hamiltonian.pathCodeLegnth; i ++)
            {
                pathCode = SetBitValue(pathCode, i, GetBit(subPixel[i], 1));
            }

            return pathCode;
        }

        private void DataExtracting(int []subPixel, BitArray subData)
        {
            var paths = hamiltonian.getPath(h, w);
            int pathCode = ExtractPathCode(subPixel), c = 0;
           // Console.WriteLine(pathCode + " " + hamiltonian.pathCodeLegnth);

            foreach(var node in paths[pathCode])
            {
               // Console.Write(node + " ");
                subData[node] = (GetBit(subPixel[c++], 0) == 1);
            }
        }

        private void DataExtracting(List < int > pixel, int s, ref int c)
        {
            BitArray subData = new BitArray(h * w);
            int []subPixel = new int[h * w];
            int len = 0;

            for (int i = s; s < pixel.Count && c < dataSize; i++, len++, s++, c++)
            {
                if(len % (h * w) == 0 && len != 0)
                {
                    DataExtracting(subPixel, subData);

                    for(int j = 0; j < h * w; j++)
                    {
                        data[c - (h * w) + j] = subData[j];
                       // Console.Write(subData[j]);
                    }
                }

                subPixel[len % (h * w)] = pixel[s];
            }

            if(len % (h * w) == 0) // handeling last subData if it Multiple of (h * w)
            {
                DataExtracting(subPixel, subData);

                for (int j = 0; j < h * w; j++)
                {
                    data[c - (h * w) + j] = subData[j];
                   // Console.Write(subData[j]);
                }
            }

            for(int i = 0; i < len % (h * w); i ++)
            {
                data[c - len % (h * w) + i] = (GetBit(pixel[s - len % (h * w) + i], 0) == 1);
            }
        }
      
        public BitArray GetData()
        {
            GetMetaData();
          //  Console.WriteLine(h + " " + w + " " + dataSize + " " + fileTypeCode);
            data = new BitArray(dataSize);
            hamiltonian = new Hamiltonian();
            int c = 0;

            DataExtracting(red, dataOverHead, ref c);

            if(c < dataSize)
                DataExtracting(green, 0, ref c);

            if (c < dataSize)
                DataExtracting(blue, 0, ref c);

            return data;
        }
    }
}
