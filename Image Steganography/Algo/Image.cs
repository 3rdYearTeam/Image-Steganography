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
            image = new Bitmap(path.ToString()); // O(1)
            red = new List<int>(); // O(1)
            green = new List<int>(); // O(1)
            blue = new List<int>(); // O(1)
            // O(N^2)
            for (int x = 0; x < image.Width; x++) // O(1)
            {
                for (int y = 0; y < image.Height; y++) // O(1)
                {
                    Color pixelColor = image.GetPixel(x, y); // O(1)
                    red.Add(pixelColor.R); // O(1)
                    green.Add(pixelColor.G); // O(1)
                    blue.Add(pixelColor.B); // O(1)
                }
            }
        }

        protected int Delta(int pixel, int temp) // O(1)
        {

            if (GetBit(pixel, 0) == GetBit(temp, 0) && GetBit(pixel, 1) == GetBit(temp, 1)) // O(1)
            {
                return pixel; // O(1)
            }
            else if (GetBit(pixel, 0) != GetBit(temp, 0) && GetBit(pixel, 1) == GetBit(temp, 1)) // O(1)
            {
                if (pixel % 2 == 0) // O(1)
                    return pixel + 1; // O(1)

                return pixel - 1; // O(1)
            }
            else if (GetBit(pixel, 0) == GetBit(temp, 0) && GetBit(pixel, 1) != GetBit(temp, 1)) // O(1)
            {
                if (GetBit(pixel, 1) == 0) // O(1)
                    return pixel + 2; // O(1)

                return pixel - 2; // O(1)
            }
            else
            {
                if (pixel == 0) // O(1)
                    return pixel + 3; // O(1)
                else if (pixel == 255) // O(1)
                    return pixel - 3; // O(1)
                else if (pixel % 2 == 0) // O(1)
                    return pixel - 1; // O(1)
                else
                    return pixel + 1; // O(1)
            }
        }

        
    }
}
