using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OFR.Controller;
using OFR.Model;

namespace OFR
{
    /// <summary>
    /// Interaction logic for DesktopScreen.xaml
    /// </summary>
    public partial class DesktopScreen : Window
    {
        public DesktopScreen()
        {
           
            InitializeComponent();
            FloaterImagerController floaterImager = new FloaterImagerController();

            FloaterImage floaterImage = new FloaterImage();

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(floaterImager.GenerateImageSourceUri("black_dots.png"));
            image.EndInit();
            image1.Source = image;

            
            //floaterImage.Id = 100;
            //floaterImage.ImageName = floaterImager.GenerateImageSourceUri("black_dots.png");
            
            this.DataContext = floaterImage;

        }

        private void GridMain()
        {
            
        }
    }

}
