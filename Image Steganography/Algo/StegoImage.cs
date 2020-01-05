using System.Collections;
using System.Collections.Generic;
using static Image_Steganography.Tools;

namespace Image_Steganography
{
    class StegoImage : Image
    {
        private int h, w, dataSize, fileTypeCode;// O(1)
        private Hamiltonian hamiltonian;// O(1)
        private BitArray data;// O(1)
        private void GetMetaData()// O(1)
        {
            int c = 0;// O(1)
            dataSize = h = w = 0;// O(1)
            // extrating block height
            // O(1)
            for (int i = 0; i < blockBits; i++, c++)// O(1)
            {
                h |= ((red[i] & 1) << c);// O(1)
            }

            c = 0;// O(1)
            // extracting block width
            // O(1)
            for (int i = blockBits; i < 2 * blockBits; i++, c++)// O(1)
            {
                w |= ((red[i] & 1) << c);// O(1)
            }

            c = 0;// O(1)
            // extracting data Size
            for (int i = 2 * blockBits; i < 2 * blockBits + dataBits; i ++, c++)
            {
                dataSize |= ((red[i] & 1) << c);
            }

            c = 0;// O(1)
            // extracting code of file Type 
            for (int i = dataOverHead - fileTypeBits; i < dataOverHead; i++, c++)// O(1)
            {
                fileTypeCode |= ((red[i] & 1) << c);// O(1)
            }
        }

        private int ExtractPathCode(int []subPixel)// O(P) , p = path length
        {
            int pathCode = 0;// O(1)

            for (int i = 0; i < hamiltonian.pathCodeLegnth; i ++)// O(1)
            {
                pathCode = SetBitValue(pathCode, i, GetBit(subPixel[i], 1));// O(1)
            }

            return pathCode;// O(1)
        }

        private void DataExtracting(int []subPixel, BitArray subData)// O(N)
        {
            var paths = hamiltonian.getPath(h, w);// O(1)
            int pathCode = ExtractPathCode(subPixel), c = 0;// O(1)
             // Console.WriteLine(pathCode + " " + hamiltonian.pathCodeLegnth)
             // O(N)
            foreach (var node in paths[pathCode])
            {
               // Console.Write(node + " ");
                subData[node] = (GetBit(subPixel[c++], 0) == 1); // O(1)
            }
        }

        private void DataExtracting(List < int > pixel, int s, ref int c) // O(N^2)
        {
            BitArray subData = new BitArray(h * w); // O(1)
            int []subPixel = new int[h * w];// O(1)
            int len = 0;// O(1)
            // O(N^2)
            for (int i = s; s < pixel.Count && c < dataSize; i++, len++, s++, c++)// O(1)
            {
                if(len % (h * w) == 0 && len != 0)// O(1)
                {
                    DataExtracting(subPixel, subData); // O(N)

                    for (int j = 0; j < h * w; j++)// O(1)
                    {
                        data[c - (h * w) + j] = subData[j];// O(1)
                        // Console.Write(subData[j]);
                    }
                }

                subPixel[len % (h * w)] = pixel[s];// O(1)
            }

            if(len % (h * w) == 0)// O(1) // handeling last subData if it Multiple of (h * w)
            {
                DataExtracting(subPixel, subData);// O(N)
                // O(1)
                for (int j = 0; j < h * w; j++)// O(1)
                {
                    data[c - (h * w) + j] = subData[j];// O(1)
                   // Console.Write(subData[j]);
                }
            }

            for(int i = 0; i < len % (h * w); i ++)// O(1)
            {
                data[c - len % (h * w) + i] = (GetBit(pixel[s - len % (h * w) + i], 0) == 1);// O(1)
            }
        }
      
        public BitArray GetData() // O(2^N * N^2 + N^2)
        {
            GetMetaData();// O(1)
            data = new BitArray(dataSize);// O(N)
            hamiltonian = new Hamiltonian();// O(1)
            int c = 0;// O(1)

            DataExtracting(red, dataOverHead, ref c);// O(2^N * N^2 + N^2)

            if (c < dataSize)// O(1)
                DataExtracting(green, 0, ref c);// O(N^2)

            if (c < dataSize)// O(1)
                DataExtracting(blue, 0, ref c);// O(N62)

            return data;// O(1)
        }
    }
}
