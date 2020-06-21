
using System.Drawing;
using System.IO;
using System.Linq;

namespace NeuralNetworkClasses
{
    public class ImageConverter
    {
        public ImageConverter(){}
        public double[] ConvertImage(string path)
        {
            Bitmap newImage = new Bitmap(path);
            var resized = new Bitmap(newImage, newImage.Height / 10, newImage.Width / 10);
            var PixelArray = new double[resized.Height * resized.Width];
            for (int i = 0; i < resized.Height; i++)
            {
                for (int j = 0; j < resized.Width; j++)
                {
                    var temp = resized.GetPixel(i, j);
                    PixelArray[i + j] = (temp.R + temp.G + temp.B) / 3.0;
                }
            }
            return PixelArray;
        }
        public double[] ConvertImage(Image newImage)
        {
            var resized = new Bitmap(newImage, newImage.Height / 10, newImage.Width / 10);
            var PixelArray = new double[resized.Height * resized.Width];
            for (int i = 0; i < resized.Height; i++)
            {
                for (int j = 0; j < resized.Width; j++)
                {
                    var temp = resized.GetPixel(j, i);
                    PixelArray[i + j] = (0.3 * temp.R + 0.6 * temp.G + 0.1 * temp.B);
                }
            }
            return PixelArray;
        }
        public Image[] LoadImages(string folderPath, int count)
        {
            string searchPattern = "*.*";
            Image[] LoadedImages = new Image[count];
            LoadedImages = Directory.GetFiles(folderPath, searchPattern).Select(Image.FromFile).ToArray();
            return LoadedImages;
        }
    }
}
