using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyDex.Utils
{
    class ImageUtils
    {
        public static Image NoirEtBlanc(Image image)
        {
            Bitmap bmp = new Bitmap(image);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color pixel = bmp.GetPixel(i, j);
                    if (pixel.A == 0) // Vérifie si le pixel est transparent
                    {
                        continue; // Ne pas modifier les pixels transparents
                    }
                    int moyenne = (pixel.R + pixel.G + pixel.B) / 3;
                    bmp.SetPixel(i, j, Color.FromArgb(pixel.A, moyenne, moyenne, moyenne));
                }
            }
            return bmp;
        }
    }
}
