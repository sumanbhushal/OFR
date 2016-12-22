using System;
using System.Collections.Generic;
using System.Configuration;
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
using OFR.Properties;

namespace OFR
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        private readonly List<FloaterImage> fImages = new List<FloaterImage>();
        private string setImageName;
        private double setNewOpacityValue;
        private readonly BaseController _floaterImagerController = new BaseController();
        public Setting()
        {
            InitializeComponent();

            PopulateListViewWithImage();
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
            }
            setImageName = ImgName;
            ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);

        }

        private void ClearGirdDataWithOpacity(string imgName, double opacityValue)
        {
            //MessageBox.Show(imgName + opacityValue); used
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
            // MessageBox.Show(imgName + " " + opacityValue); Used
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
                    //setImageName = "blackdots.gif";
                    setImageName = Settings.Default["ImageName"].ToString();
                    slider.Value = Convert.ToDouble(Settings.Default["Opacity"].ToString());
                    ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);
                }
                else
                {
                    ClearGirdDataWithOpacity(setImageName, setNewOpacityValue);
                }
            }
        }

        private void SetImageAndOpacityToScreen(object sender, RoutedEventArgs e)
        {
            Settings.Default["ImageName"] = setImageName;
            Settings.Default["Opacity"] = setNewOpacityValue;
            Settings.Default.Save();

            //GifAnimation ani = new GifAnimation();
            //ani.Show();
            bool isWindowOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is GifAnimation)
                {
                    isWindowOpen = true;
                    w.Close();
                    GifAnimation newwindow = new GifAnimation();
                    newwindow.Show();
                    //w.Activate();
                }
            }

            if (!isWindowOpen)
            {
                GifAnimation newwindow = new GifAnimation();
                newwindow.Show();
            }
        }

    }
}
