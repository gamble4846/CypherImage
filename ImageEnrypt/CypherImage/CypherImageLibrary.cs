using CypherImage.Model;
using CypherImage.Utility;
using System.Drawing;

namespace CypherImage
{
    public class CypherImageLibrary
    {
        public static byte[] Encrypt(byte[] inputBytes, string Key)
        {
            int MoveCount = CommonFunctions.GetMovesCountByKey(Key);
            return MovePixelsImage(inputBytes, MoveCount, true);
        }

        public static byte[] Decrypt(byte[] inputBytes, string Key)
        {
            int MoveCount = CommonFunctions.GetMovesCountByKey(Key);
            return MovePixelsImage(inputBytes, MoveCount, false);
        }

        private static byte[] MovePixelsImage(byte[] inputBytes, int MoveCount, bool IsEncrypt)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(inputBytes))
            {
                bmp = new Bitmap(ms);
            }

            List<List<ColorWapper>> PixalDoubleArray = new List<List<ColorWapper>>();

            Bitmap NewBmp = bmp;


            for (int i = 0; i < bmp.Width; i++)
            {
                List<ColorWapper> JUSTHights = new List<ColorWapper>();
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color pixel = bmp.GetPixel(i, j);
                    ColorWapper wrap = new ColorWapper()
                    {
                        Color = pixel,
                    };
                    JUSTHights.Add(wrap);
                }
                PixalDoubleArray.Add(JUSTHights);
            }

            if (IsEncrypt)
            {
                PixalDoubleArray = EncryptImage(PixalDoubleArray, MoveCount);
            }
            else
            {
                PixalDoubleArray = DecryptImage(PixalDoubleArray, MoveCount);
            }



            for (int i = 0; i < PixalDoubleArray.Count; i++)
            {
                for (int j = 0; j < PixalDoubleArray[i].Count; j++)
                {
                    NewBmp.SetPixel(i, j, PixalDoubleArray[i][j].Color);
                }
            }

            using (var stream = new MemoryStream())
            {
                NewBmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        private static List<List<ColorWapper>> EncryptImage(List<List<ColorWapper>> PixalDoubleArray, int MoveCount)
        {
            for (int i = 0; i < PixalDoubleArray.Count; i++)
            {
                PixalDoubleArray[i] = ShuffleExtensions.Shuffle(PixalDoubleArray[i], MoveCount);
            }

            PixalDoubleArray = ShuffleExtensions.Shuffle(PixalDoubleArray, MoveCount);

            return PixalDoubleArray;
        }

        private static List<List<ColorWapper>> DecryptImage(List<List<ColorWapper>> PixalDoubleArray, int MoveCount)
        {
            PixalDoubleArray = ShuffleExtensions.DeShuffle(PixalDoubleArray, MoveCount);

            for (int i = 0; i < PixalDoubleArray.Count; i++)
            {
                PixalDoubleArray[i] = ShuffleExtensions.DeShuffle(PixalDoubleArray[i], MoveCount);
            }

            return PixalDoubleArray;
        }
    }
}
