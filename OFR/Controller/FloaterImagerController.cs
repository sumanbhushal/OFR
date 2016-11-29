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
using WpfAnimatedGif;

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
            imageToReturn.Opacity = 0.18;
            imageToReturn.Stretch = Stretch.UniformToFill;
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
                To = 0.25,
                AutoReverse = true,
                Duration = new Duration(TimeSpan.FromSeconds(2.5)),
                RepeatBehavior = RepeatBehavior.Forever
            };

            Storyboard.SetTarget(da, imageForAnimation);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity", 0.25));
            Storyboard sb = new Storyboard();
            sb.Children.Add(da);
            sb.Begin(imageForAnimation);

            }

        public void CombineRotationWithSkewAnimation(Image imageForAnimation)
        {
            //Define DoubleAnimation for Translate Transform
            DoubleAnimation daTranslateX = GenerateDoubleAnimation(300,60);
            DoubleAnimation daTranslateY = GenerateDoubleAnimation(300,60);

            DoubleAnimation daRotate = GenerateDoubleAnimation(360,60);
           
            //RotateTransform rt = new RotateTransform();
            //imageForAnimation.RenderTransform = rt;
            //imageForAnimation.RenderTransformOrigin = new Point(0.75, 0.75);
            //rt.BeginAnimation(RotateTransform.AngleProperty, daRotate);
            //rt.BeginAnimation(RotateTransform.CenterXProperty, daTranslateX);
            //rt.BeginAnimation(RotateTransform.CenterYProperty, daTranslateY);

            DoubleAnimation daSkewX = GenerateDoubleAnimation(43,30);
            DoubleAnimation daSkewY = GenerateDoubleAnimation(43,30);
            
            imageForAnimation.RenderTransform = new SkewTransform();
            imageForAnimation.RenderTransform.BeginAnimation(SkewTransform.AngleXProperty, daSkewX);
            imageForAnimation.RenderTransform.BeginAnimation(SkewTransform.AngleYProperty, daSkewY);

        }
    

        DoubleAnimation GenerateDoubleAnimation(int max, double time)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = max;
            da.AutoReverse = true;
            da.Duration = new Duration(TimeSpan.FromSeconds(time));
            da.RepeatBehavior = RepeatBehavior.Forever;

            return da;
        }

        public Image LoadAnimationImage(string imageName)
        {
            Image imageToReturn = new Image();
            imageToReturn.Opacity = 0.18;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(GenerateImageSourceUri(imageName));
            image.EndInit();
            ImageBehavior.SetAnimatedSource(imageToReturn, image);
            //imageToReturn.Source = image;

            //return RotationAnimation(imageToReturn);
            return imageToReturn;
        }
    }
}
