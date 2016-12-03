﻿using System;
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

namespace OFR
{
    /// <summary>
    /// Interaction logic for GifAnimation.xaml
    /// </summary>
    public partial class GifAnimation : Window
    {
        private System.Windows.Forms.NotifyIcon notifyIcon = null;

        public GifAnimation()
        {
            InitializeComponent();
            FloaterImagerController floaterImagerController = new FloaterImagerController();

            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var floaterImage = floaterImagerController.LoadAnimationImage("blackdots.gif");
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
