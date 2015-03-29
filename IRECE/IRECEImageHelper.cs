using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace IRECE
{
    public static class IRECEImageHelper
    {
        public static string ImageToBase64String(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, image.RawFormat);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static Image ImageFromBase64String(string base64String)
        {
            using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64String)))
            using (Image sourceImage = Image.FromStream(stream))
            {
                return new Bitmap(sourceImage);
            }
        }
    }
}
