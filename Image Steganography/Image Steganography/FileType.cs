using System;
using System.Collections;
using System.Text;
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
        static public Object GetCorrespondingData(BitArray data, FileType fileType, string key = "", string path = "")
        {
            Object CorrespondingData = new object();

            if(fileType == FileType.text)
            {
                CorrespondingData = ConvertToText(data);
            }
            else if (fileType == FileType.image)
            {
                CorrespondingData = ConvertToImage(data, key, path);
            }
            else if (fileType == FileType.audio)
            {
            //    ConvertToImage(data);
            }

            return CorrespondingData;
        }

        static private StringBuilder ConvertToText(BitArray Data)
        {
            StringBuilder text = new StringBuilder("");
            int character = 0, x = 0, i;

            for(i = 0; i < Data.Length; i ++)
            {
                if (i % 8 == 0 && i != 0)
                {
                    text.Append((char)character);
                }

                if (Data[i])
                    x = 1;
                else
                    x = 0;

                character = SetBitValue(character, i % 8, x);
            }

            if (i % 8 == 0)
            {
                text.Append((char)character);
            }

            return text;
        }

        private static string ConvertToImage(BitArray Data, string key, string path)
        {
            var text = ConvertToText(Data);
            var encryptedData = ImageCyptography.Decrypt(text.ToString(), key);
            var bytes = ImageCyptography.ConvertStringToBytes(encryptedData.ToString());
            path = ImageCyptography.BytesArrayToImage(bytes, path);
            return path;
        }

    }
}
