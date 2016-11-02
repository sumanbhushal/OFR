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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }
        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);

        //    // Get this window's handle
        //    IntPtr hwnd = new WindowInteropHelper(this).Handle;

        //    Win32.makeTransparent(hwnd);
        //}
    }
}
