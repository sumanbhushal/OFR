using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OFR.Controller;

namespace OFR
{
    /// <summary>
    /// Interaction logic for SettingScreen.xaml
    /// </summary>
    public partial class SettingScreen : Window
    {
        private readonly FloaterImagerController _floaterImagerController = new FloaterImagerController();
        public SettingScreen()
        {
            InitializeComponent();
            LoadSelectedAnimatedImage();

            //var floaterImage = floaterImagerController.LoadAnimationImage("blackdots.gif");
            //BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.UriSource = new Uri(_floaterImagerController.GenerateImageSourceUri("ico.png"));
            //image.EndInit();
            //PreviewImage.Source = image;

        }

        private void LboxItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        public void LoadSelectedAnimatedImage()
        {
            ImageBrush backgroundImageBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                   "pack://application:,,,/Include/setting_background.JPG"));
            backgroundImageBrush.ImageSource = image.Source;
            backgroundImageBrush.Stretch = Stretch.Uniform;
            ImageBorder.Background = backgroundImageBrush;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    var floaterImage = _floaterImagerController.LoadAnimationImage("blackdots.gif");
                    _floaterImagerController.RotationAnimation(floaterImage);
                    Grid.SetColumn(floaterImage, i);
                    Grid.SetRow(floaterImage, j);
                    Gride4X4.Children.Add(floaterImage);

                    
                }
            }
            
        }
        
    }
}
