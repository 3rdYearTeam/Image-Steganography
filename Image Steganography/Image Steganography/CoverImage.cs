using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.IO;
using static Image_Steganography.Tools;

namespace Image_Steganography
{
    class CoverImage : Image
    {
        private const int h = 3, w = 3;
        private Hamiltonian hamiltonian;
        private void SetBlockSize()
        {
            int c = 0;

            for(int i = 0; i < blockBits; i ++, c++)
            {
                red[i] = SetBitValue(red[i], 0, (h & (1 << c)));
            }

            c = 0;

            for (int i = blockBits; i < 2 * blockBits; i++, c++)
            {
                red[i] = SetBitValue(red[i], 0, (w & (1 << c)));
            }
        }

        private void SetDataSize(int dataSize) 
        {
            int c = 0;

            for(int i = 2 * blockBits; i < 2 * blockBits + dataBits; i++, c++)
            {
                red[i] = SetBitValue(red[i], 0, (dataSize & (1 << c)));
            }
        }

        private void SetFileType(int fileTypeCode)
        {
            int c = 0;

            for (int i = dataOverHead - fileTypeBits; i < dataOverHead; i++, c++)
                red[i] = SetBitValue(red[i], 0, GetBit(fileTypeCode, c));
        }

        private double MatchPath(List <int> path, int []pixel, BitArray data, int pathCode, bool apply = false)
        {
            double MSE = 0;
            int c = 0;
            List<int> temp = new List<int>(new int [pixel.Length]);

            // not ok
            foreach (var node in path)
            {
                int x = 0;

                if (data[node])
                {
                    x = 1;
                }

                temp[c] = SetBitValue(pixel[c], 0, x);
                c++;
            }

            for (int i = 0; i < hamiltonian.pathCodeLegnth; i++)
            {
                temp[i] = SetBitValue(temp[i], 1, GetBit(pathCode, i));
                temp[i] = Delta(pixel[i], temp[i]);
            }

            for (int i = 0; i < temp.Count; i++)
            {
                MSE += Math.Pow(pixel[i] - temp[i], 2);

                if (apply)
                {
                    pixel[i] = temp[i]; 
                }
            }

            return MSE / path.Count;
        }

        private void EmbedBestPath(List < int > pixel, int s, int []subPixels, BitArray subData)
        {
            var paths = hamiltonian.getPath(h, w);
            double MSE = 1e9;
            int pathCode = 0;

            foreach (var path in paths)
            {
                var ret = MatchPath(path.Value, subPixels, subData, path.Key);
                if (MSE > ret)
                {
                    MSE = ret;
                    pathCode = path.Key;
                }
            }

            MatchPath(paths[pathCode], subPixels, subData, pathCode, true);
          //  Console.WriteLine(pathCode + " " + hamiltonian.pathCodeLegnth);

            for (int j = 0; j < h * w; j++)
            {
                pixel[s - (h * w) + j] = subPixels[j];
            }
        }

        private void DataEmbedding(List < int > pixel, int s, BitArray data, ref int c)
        {
            BitArray subData = new BitArray(h * w);
            int [] subPixels = new int [h * w];
            int len = 0;

            for (int i = s; c < data.Length && i < pixel.Count; i++, len++, c++, s++)
            {
                if (len % (h * w) == 0 && len != 0)
                {
                    EmbedBestPath(pixel, s, subPixels, subData);
                }

                subData[len % (h * w)] = data[c];
                subPixels[len % (h * w)] = pixel[s];
            }

            if(len % (h * w) == 0) // handeling last subData if it Multiple of (h * w)
                EmbedBestPath(pixel, s, subPixels, subData);

            for (int i = 0; i < len % (h * w); i ++)
            {
                int x = 0;

                if (data[c - len % (h * w) + i])
                {
                    x = 1;
                }

                pixel[s - len % (h * w) + i] = SetBitValue(pixel[s - len % (h * w) + i], 0, x);
            }
        }

        public void EmbedData(BitArray data, int FileTypeCode)
        {
            if(data.Count > (image.Width * image.Height * 3) - dataOverHead)
            {
                Console.WriteLine("FILE SIZE IS TOOOOOO BIG");
                return;
            }
         //   Console.WriteLine(h + " " + w);
            int c = 0;
            hamiltonian = new Hamiltonian();
            SetBlockSize();
            SetDataSize(data.Length);
            SetFileType(FileTypeCode);
            DataEmbedding(red, dataOverHead, data, ref c);

            if(c != data.Count)
                DataEmbedding(green, 0, data, ref c);

            if (c != data.Count)
                DataEmbedding(blue, 0, data, ref c);
        }

        public void SaveImage(string path)
        {
            int idx = 0;
            
            for(int x = 0; x < image.Width; x++)
                for(int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = Color.FromArgb(red[idx], green[idx], blue[idx]);
                    image.SetPixel(x, y, pixelColor);
                    idx++;
                }
         
            image.Save(path);
        }
    }
}
