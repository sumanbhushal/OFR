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
using OFR.Model;

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
            List<FloaterImage> fImages = new List<FloaterImage>(); 
            fImages.Add(new FloaterImage() {ImageName = "blackdots.gif", ImageSourceLocation = "pack://application:,,,/Include/blackdots.gif" });
            fImages.Add(new FloaterImage() { ImageName = "black_dots.png", ImageSourceLocation = "pack://application:,,,/Include/black_dots.png" });
            LboxItem.ItemsSource = fImages;

            var firstItemFromList = fImages.First();
            var imagerName = firstItemFromList.ImageName;
            LoadSelectedAnimatedImageWithImageName(imagerName);

            //var floaterImage = floaterImagerController.LoadAnimationImage("blackdots.gif");
            //BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.UriSource = new Uri(_floaterImagerController.GenerateImageSourceUri("ico.png"));
            //image.EndInit();
            //PreviewImage.Source = image;

        }

        private void LboxItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ImgName = "";
            
            foreach (object obj in LboxItem.SelectedItems)
            {
                
                ImgName = (obj as FloaterImage).ImageName;
                //MessageBox.Show((obj as FloaterImage).ImageName);
            }
            ClearGirdData(ImgName);

        }

        private void ClearGirdData(string imgName)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    foreach (UIElement control in Gride4X4.Children)
                    {
                        if (Grid.GetRow(control) == j && Grid.GetColumn(control) == i)
                        {
                            Gride4X4.Children.Remove(control);
                            break;
                        }
                    }  
                }
            }
            LoadSelectedAnimatedImageWithImageName(imgName);

        }

        private void LoadSelectedAnimatedImageWithImageName(string imgName)
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
                    
                    var floaterImage = _floaterImagerController.LoadAnimationImage(imgName);
                    _floaterImagerController.RotationAnimation(floaterImage);
                    Grid.SetColumn(floaterImage, i);
                    Grid.SetRow(floaterImage, j);
                    Gride4X4.Children.Add(floaterImage);
                    
                }
            }
        }


        //public void LoadSelectedAnimatedImage()
        //{
        //    ImageBrush backgroundImageBrush = new ImageBrush();
        //    Image image = new Image();
        //    image.Source = new BitmapImage(
        //        new Uri(
        //           "pack://application:,,,/Include/setting_background.JPG"));
        //    backgroundImageBrush.ImageSource = image.Source;
        //    backgroundImageBrush.Stretch = Stretch.Uniform;
        //    ImageBorder.Background = backgroundImageBrush;

        //    for (int i = 0; i < 6; i++)
        //    {
        //        for (int j = 0; j < 6; j++)
        //        {
        //            var floaterImage = _floaterImagerController.LoadAnimationImage("blackdots.gif");
        //            _floaterImagerController.RotationAnimation(floaterImage);
        //            Grid.SetColumn(floaterImage, i);
        //            Grid.SetRow(floaterImage, j);
        //            Gride4X4.Children.Add(floaterImage);

                    
        //        }
        //    }
            
        //}
        
    }
}
