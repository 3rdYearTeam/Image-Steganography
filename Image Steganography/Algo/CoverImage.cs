using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using static Image_Steganography.Tools;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace Image_Steganography
{
    class CoverImage : Image
    {
        private const int h = 3, w = 3; // O(1)
        private Hamiltonian hamiltonian;  // O(1)
        private void SetBlockSize() // O(1)
        {
            int c = 0; // O(1)
            // O(1)
            for (int i = 0; i < blockBits; i ++, c++) // O(1)
            {
                red[i] = SetBitValue(red[i], 0, (h & (1 << c))); // O(1)
            }

            c = 0; // O(1)
            // O(1)
            for (int i = blockBits; i < 2 * blockBits; i++, c++) // O(1)
            {
                red[i] = SetBitValue(red[i], 0, (w & (1 << c))); // O(1)
            }
        }

        private void SetDataSize(int dataSize)  // O(1)
        {
            int c = 0; // O(1)

            for (int i = 2 * blockBits; i < 2 * blockBits + dataBits; i++, c++) // O(1)
            {
                red[i] = SetBitValue(red[i], 0, (dataSize & (1 << c))); // O(1)
            }
        }

        private void SetFileType(int fileTypeCode) // O(1)
        {
            int c = 0; // O(1)

            for (int i = dataOverHead - fileTypeBits; i < dataOverHead; i++, c++) // O(1)
                red[i] = SetBitValue(red[i], 0, GetBit(fileTypeCode, c)); // O(1)
        }

        private double MatchPath(List <int> path, int []pixel, BitArray data, int pathCode, bool apply = false) // O(N)
        {
            double MSE = 0; // O(1)
            int c = 0; // O(1)
            List<int> temp = new List<int>(new int [pixel.Length]); // O(N)

            // O(N)
            foreach (var node in path) // O(1)
            {
                int x = 0; // O(1)

                if (data[node]) // O(1)
                {
                    x = 1; // O(1)
                }

                temp[c] = SetBitValue(pixel[c], 0, x); // O(1)
                c++; // O(1)
            }
            // O(1)
            for (int i = 0; i < hamiltonian.pathCodeLegnth; i++) // O(1)
            {
                temp[i] = SetBitValue(temp[i], 1, GetBit(pathCode, i)); // O(1)
                temp[i] = Delta(pixel[i], temp[i]); // O(1)
            }
            // O(N)
            for (int i = 0; i < temp.Count; i++) // O(1)
            {
                MSE += Math.Pow(pixel[i] - temp[i], 2); // O(1)

                if (apply) // O(1)
                {
                    pixel[i] = temp[i];  // O(1)
                }
            }

            return MSE / path.Count; // O(1)
        }

        private void EmbedBestPath(List < int > pixel, int s, int []subPixels, BitArray subData) // O(N^2)
        {
            var paths = hamiltonian.getPath(h, w); // O(1)
            double MSE = 1e9; // O(1)
            int pathCode = 0; // O(1)
             // O(N^2)
            foreach (var path in paths) // O(1)
            {
                var ret = MatchPath(path.Value, subPixels, subData, path.Key); // O(N)
                if (MSE > ret) // O(1)
                {
                    MSE = ret; // O(1)
                    pathCode = path.Key; // O(1)
                }
            }

            MatchPath(paths[pathCode], subPixels, subData, pathCode, true); // O(N)

            for (int j = 0; j < h * w; j++) // O(1)
            {
                pixel[s - (h * w) + j] = subPixels[j]; // O(1)
            }
        }

        private void DataEmbedding(List < int > pixel, int s, BitArray data, ref int c) // O(N^3)
        {
            BitArray subData = new BitArray(h * w); // O(1)
            int [] subPixels = new int [h * w]; // O(1)
            int len = 0; // O(1)
            // O(N^#)
            for (int i = s; c < data.Length && i < pixel.Count; i++, len++, c++, s++) // O(1)
            {
                if (len % (h * w) == 0 && len != 0) // O(1)
                {
                    EmbedBestPath(pixel, s, subPixels, subData); // O(N^2)
                }

                subData[len % (h * w)] = data[c]; // O(1)
                subPixels[len % (h * w)] = pixel[s]; // O(1)
            }
            // O(1)
            if (len % (h * w) == 0) // handeling last subData if it Multiple of (h * w)
                EmbedBestPath(pixel, s, subPixels, subData); // O(N^2)
            // O(1)
            for (int i = 0; i < len % (h * w); i ++) // O(1)
            {
                int x = 0; // O(1)

                if (data[c - len % (h * w) + i]) // O(1)
                {
                    x = 1; // O(1)
                }

                pixel[s - len % (h * w) + i] = SetBitValue(pixel[s - len % (h * w) + i], 0, x); // O(1)
            }
        }

        public bool EmbedData(BitArray data, int FileTypeCode) // O(2^n * n^2 + N^3)
        {
            if(data.Count > (image.Width * image.Height * 3) - dataOverHead) // O(1)
            {
                MessageBox.Show("FILE SIZE IS TOOOOOO BIG"); // O(1)
                return false; // O(1)
            }
         //   Console.WriteLine(h + " " + w);
            int c = 0; // O(1)
            hamiltonian = new Hamiltonian(); // O(1)
            SetBlockSize(); // O(1)
            SetDataSize(data.Length); // O(1)
            SetFileType(FileTypeCode); // O(1)
            DataEmbedding(red, dataOverHead, data, ref c); // O(2^n * n^2)

            if (c != data.Count) //O(1)
                DataEmbedding(green, 0, data, ref c);//O(N^3)

            if (c != data.Count)//O(1)
                DataEmbedding(blue, 0, data, ref c); //O(N^3);

            return true;//O(1)
        }

        //O(N^2)
        public void SaveImage(String path)
        {
            int idx = 0;//O(1)
            //O(N^2)
            for (int x = 0; x < image.Width; x++)//O(1)
            {
                //O(N)
                for (int y = 0; y < image.Height; y++)//O(1)
                {
                    Color pixelColor = Color.FromArgb(red[idx], green[idx], blue[idx]);//O(1)
                    image.SetPixel(x, y, pixelColor);//O(1)
                    idx++;//O(1)
                }
            }

            image.Save(path.ToString(), ImageFormat.Png);//O(1)
        }
    }
}
