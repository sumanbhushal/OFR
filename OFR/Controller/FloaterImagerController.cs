using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
            imageToReturn.Opacity = 0.15;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(GenerateImageSourceUri("black_dots.png"));
            image.EndInit();
            imageToReturn.Source = image;
            
            //return RotationAnimation(imageToReturn);
            return imageToReturn;
        }

        public void RotationAnimation(Image imageForAnimation)
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = 75,
                AutoReverse = true,
                Duration = new Duration(TimeSpan.FromSeconds(60)),
                RepeatBehavior = RepeatBehavior.Forever
            };
            RotateTransform rt = new RotateTransform();
            imageForAnimation.RenderTransform = rt;
            imageForAnimation.RenderTransformOrigin = new Point(0.75, 0.75);
            rt.BeginAnimation(RotateTransform.AngleProperty,da);
        }

        public void SkewAnimation(Image imageForAnimation)
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = 15,
                AutoReverse = true,
                Duration = new Duration(TimeSpan.FromSeconds(4)),
                //EasingFunction = new BackEase(),
                RepeatBehavior = RepeatBehavior.Forever
                
            };
            imageForAnimation.RenderTransform = new SkewTransform();
            imageForAnimation.RenderTransform.BeginAnimation(SkewTransform.AngleXProperty,da);
        }

        public void FadeInOutAnimation(Image imageForAnimation)
        {
            DoubleAnimation da = new DoubleAnimation
            {
                From = 0,
                To = 0.3,
                AutoReverse = true,
                Duration = new Duration(TimeSpan.FromSeconds(2.5)),
                RepeatBehavior = RepeatBehavior.Forever
            };
            //imageForAnimation.BeginAnimation("Opicity",da);
            Storyboard.SetTarget(da, imageForAnimation);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity", 0.3));
            Storyboard sb = new Storyboard();
            sb.Children.Add(da);
            sb.Begin(imageForAnimation);

            //imageForAnimation.BeginAnimation(new PropertyPath(imageForAnimation.Opacity, 1), da);
        }
    }
}
