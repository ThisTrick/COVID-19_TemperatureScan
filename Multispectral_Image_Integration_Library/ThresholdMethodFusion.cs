using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multispectral_Image_Integration_Library
{
    public class ThresholdMethodFusion : IImageFusion
    {
        public int Threshold { get; }

        public FastBitmap Fusion(FastBitmap img1, FastBitmap img2)
        {
            if (img1.Width != img2.Width || img2.Height != img2.Height)
            {
                throw new ArgumentException("Изображения должны быть одного размера");
            }
            var imgResult = img1.Clone();
            for (int x = 0; x < imgResult.Width; x++)
            {
                for (int y = 0; y < imgResult.Height; y ++)
                {
                    var intensity = (int)(0.59 * img2[x, y, 0] + 0.3 * img2[x, y, 1] + 0.11 * img2[x, y, 2]);
                    if (intensity >= Threshold)
                    {
                        imgResult[x, y, 0] = img2[x, y, 0];
                        imgResult[x, y, 1] = img2[x, y, 1];
                        imgResult[x, y, 2] = img2[x, y, 2];
                    }
                }
            }
            return imgResult;
        }
        public ThresholdMethodFusion(int threshold)
        {
            Threshold = threshold;
        }
    }
}
