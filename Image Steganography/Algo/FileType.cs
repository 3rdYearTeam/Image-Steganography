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
            Object CorrespondingData = new object();// O(1)

            if (fileType == FileType.text)// O(1)
            {
                CorrespondingData = ConvertToText(data);// O(1)
            }
            else if (fileType == FileType.image)// O(1)
            {
                CorrespondingData = ConvertToImage(data, key, path);// O(1)
            }
            else if (fileType == FileType.audio)
            {
            //    ConvertToImage(data);
            }

            return CorrespondingData;
        }

        static private StringBuilder ConvertToText(BitArray Data)// O(N)
        {
            StringBuilder text = new StringBuilder("");// O(1)
            int character = 0, x = 0, i;// O(1)
            // O(N)
            for (i = 0; i < Data.Length; i ++)// O(1)
            {
                if (i % 8 == 0 && i != 0)// O(1)
                {
                    text.Append((char)character);// O(1)
                }

                if (Data[i])// O(1)
                    x = 1;// O(1)
                else
                    x = 0;// O(1)

                character = SetBitValue(character, i % 8, x);// O(1)
            }

            if (i % 8 == 0)// O(1)
            {
                text.Append((char)character);// O(1)
            }

            return text;// O(1)
        }

        private static string ConvertToImage(BitArray Data, string key, string path) // O(N)
        {
            var text = ConvertToText(Data);// O(N)
            var encryptedData = ImageCyptography.Decrypt(text.ToString(), key);// O(N)
            var bytes = ImageCyptography.ConvertStringToBytes(encryptedData.ToString());  //O(N)
            path = ImageCyptography.BytesArrayToImage(bytes, path);// O(N)
            return path; //O(1)
        }

    }
}
