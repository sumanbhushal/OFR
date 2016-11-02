using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OFR.Controller
{
    public class FloaterImagerController
    {

        public string GenerateImageSourceUri(string imageName)
        {
            return "pack://application:,,,/Include/" + imageName;
        }

        public Image ImagerLoader()
        {
            Image imageToReturn = new Image();
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(GenerateImageSourceUri("black_dots.png"));
            image.EndInit();
            imageToReturn.Source = image;

            return imageToReturn;
        }
    }
}
