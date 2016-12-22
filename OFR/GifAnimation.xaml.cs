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
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace OFR
{
    /// <summary>
    /// Interaction logic for GifAnimation.xaml
    /// </summary>
    public partial class GifAnimation : Window
    {
        private System.Windows.Forms.NotifyIcon notifyIcon = null;
        //private string floaterImageName;
        BaseController floaterImagerController = new BaseController();
        public GifAnimation()
        {
            InitializeComponent();
            ClearGirdData();

            
            
        }

        private void ClearGirdData()
        {
            //MessageBox.Show(imgName + opacityValue); used
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    foreach (UIElement control in mainGrid.Children)
                    {
                        if (Grid.GetRow(control) == j && Grid.GetColumn(control) == i)
                        {
                            mainGrid.Children.Remove(control);
                            break;
                        }
                    }
                }
            }
            LoadDataInGrid();
        }

        private void LoadDataInGrid()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var floaterImage = floaterImagerController.LoadAnimationImageFromMain();
                    //floaterImagerController.CombineRotationWithSkewAnimation(floaterImage);
                    floaterImagerController.RotationAnimation(floaterImage);
                    Grid.SetColumn(floaterImage, i);
                    Grid.SetRow(floaterImage, j);
                    mainGrid.Children.Add(floaterImage);
                }
            }
        }
    }
}
