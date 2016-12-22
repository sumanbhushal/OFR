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
        private string setImageName;
        private double setNewOpacityValue;
        private readonly FloaterImagerController _floaterImagerController = new FloaterImagerController();
        private readonly List<FloaterImage> fImages = new List<FloaterImage>();
        public SettingScreen()
        {
            InitializeComponent();
            PopulateListViewWithImage();
             
            var firstItemFromList = fImages.First();
            var imagerName = firstItemFromList.ImageName;
            setImageName = imagerName;
            //LoadSelectedAnimatedImageWithImageName(setImageName);
            //LoadSelectedAnimatedImageWithImageNameAndOpacityValue(setImageName, setNewOpacityValue);
            //var floaterImage = floaterImagerController.LoadAnimationImage("blackdots.gif");
            //BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.UriSource = new Uri(_floaterImagerController.GenerateImageSourceUri("ico.png"));
            //image.EndInit();
            //PreviewImage.Source = image;

        }

        private void PopulateListViewWithImage()
        {
            fImages.Add(new FloaterImage() { ImageName = "blackdots.gif", ImageSourceLocation = "pack://application:,,,/Include/blackdots.gif" });
            fImages.Add(new FloaterImage() { ImageName = "black_dots.png", ImageSourceLocation = "pack://application:,,,/Include/black_dots.png" });
            LboxItem.ItemsSource = fImages;
        }

        private void LboxItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ImgName = "";
            
            foreach (object obj in LboxItem.SelectedItems)
            {
                
                ImgName = (obj as FloaterImage).ImageName;
                //MessageBox.Show((obj as FloaterImage).ImageName);
            }
            setImageName = ImgName;
            ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);
            //ClearGirdData(setImageName);

        }

        private void ClearGirdDataWithOpacity(string imgName, double opacityValue)
        {
            //MessageBox.Show(imgName + opacityValue);
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
            LoadSelectedAnimatedImageWithImageNameAndOpacityValue(imgName, opacityValue);

        }
        private void LoadSelectedAnimatedImageWithImageNameAndOpacityValue(string imgName, double opacityValue)
        {
           // MessageBox.Show(imgName + " " + opacityValue);
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

                    var floaterImage = _floaterImagerController.LoadAnimationImageWithOpacity(imgName, opacityValue);
                    _floaterImagerController.RotationAnimation(floaterImage);
                    Grid.SetColumn(floaterImage, i);
                    Grid.SetRow(floaterImage, j);
                    Gride4X4.Children.Add(floaterImage);

                }
            }
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

        private void opacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // ... Get Slider reference.
            var slider = sender as Slider;
            // ... Get Value.
            if (slider != null)
            {
                double OpacityValue = slider.Value;
                string new_opacity_value = OpacityValue.ToString("0.00");
                setNewOpacityValue = OpacityValue;
                if (setImageName == null)
                {
                    setImageName = "blackdots.gif";
                    ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);
                }
                else
                {
                    ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);
                }
                
                //MessageBox.Show(new_opacity_value);
                //this.Title = "Value: " + value.ToString("0.00") + "/" + slider.Maximum;
            }
        }

        private void SetImageAndOpacityToScreen(object sender, RoutedEventArgs e)
        {
           _floaterImagerController.SetImageNameAndOpacityValue(setImageName, setNewOpacityValue);
            //MessageBox.Show(setImageName + " " + setNewOpacityValue);

            GifAnimation ani = new GifAnimation();
            ani.Show();

        }
    }
}
