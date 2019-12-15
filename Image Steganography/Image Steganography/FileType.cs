using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Image_Steganography.Tools;

namespace Image_Steganography
{
    public enum FileType
    { 
        text = 0,
        image = 1,
        audio = 2
    }

    class File
    {
        static public Object GetCorrespondingData(BitArray data, FileType fileType)
        {
            Object CorrespondingData = new object();

            if(fileType == FileType.text)
            {
                CorrespondingData = ConvertToText(data);
            }
            else if (fileType == FileType.image)
            {
            //    ConvertToImage(data);
            }
            else if (fileType == FileType.audio)
            {
            //    ConvertToImage(data);
            }

            return CorrespondingData;
        }

        static private string ConvertToText(BitArray Data)
        {
            string text = "";
            int character = 0, x = 0, i;

            for(i = 0; i < Data.Length; i ++)
            {
                if (i % 8 == 0 && i != 0)
                {
                    text += (char)character;
                }

                if (Data[i])
                    x = 1;
                else
                    x = 0;

                character = SetBitValue(character, i % 8, x);
            }

            if (i % 8 == 0)
            {
                text += (char)character;
            }

            return text;
        }
    }
}
