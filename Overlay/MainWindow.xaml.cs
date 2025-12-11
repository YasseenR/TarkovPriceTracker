using System.ComponentModel;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace TarkovAssistant.Overlay
{
    public partial class MainWindow : Window
    {
        public  MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            int exStyle = (int)Win32.GetWindowLong(hwnd, Win32.GWL_EXSTYLE);

            Win32.SetWindowLong(hwnd, Win32.GWL_EXSTYLE,
                (IntPtr)(exStyle | Win32.WS_EX_TRANSPARENT | Win32.WS_EX_LAYERED));
        }

        
    }
    
    public static class Win32
    {
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_TRANSPARENT = 0x00000020; // ignore mouse input
        public const int WS_EX_LAYERED = 0x00080000;     // required for transparency

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    }
}