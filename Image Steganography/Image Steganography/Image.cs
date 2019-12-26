using System.Collections.Generic;
using System.Text;
using System.Drawing;
using static Image_Steganography.Tools;

namespace Image_Steganography
{
    class Image
    {
        protected Bitmap image;
        protected List<int> red, green, blue;
        protected const int blockBits = 3,fileTypeBits = 4, dataBits = 25, dataOverHead = dataBits + 2 * blockBits + fileTypeBits;
        public void ReadImage(String path)
        {
            image = new Bitmap(path.ToString());
            red = new List<int>();
            green = new List<int>();
            blue = new List<int>();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    red.Add(pixelColor.R);
                    green.Add(pixelColor.G);
                    blue.Add(pixelColor.B);
                }
            }
        }

        protected int Delta(int pixel, int temp)
        {

            if (GetBit(pixel, 0) == GetBit(temp, 0) && GetBit(pixel, 1) == GetBit(temp, 1))
            {
                return pixel;
            }
            else if (GetBit(pixel, 0) != GetBit(temp, 0) && GetBit(pixel, 1) == GetBit(temp, 1))
            {
                if (pixel % 2 == 0)
                    return pixel + 1;

                return pixel - 1;
            }
            else if (GetBit(pixel, 0) == GetBit(temp, 0) && GetBit(pixel, 1) != GetBit(temp, 1))
            {
                if (GetBit(pixel, 1) == 0)
                    return pixel + 2;

                return pixel - 2;
            }
            else
            {
                if (pixel == 0)
                    return pixel + 3;
                else if (pixel == 255)
                    return pixel - 3;
                else if (pixel % 2 == 0)
                    return pixel - 1;
                else
                    return pixel + 1;
            }
        }

        
    }
}
