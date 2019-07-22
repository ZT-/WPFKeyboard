using System;
using System.Windows;
using Sample.KeyTemplates;
using WPFKeyboard;

namespace Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
          
            VirtualKeyboard.OnScreenKeyControlBuilder = new SampleKeyControlBuilder();

            try
            {
                VirtualKeyboard.DataContext = new KPDOnScreenKeyboardViewModel(@"C:\Windows\System32\KBDUS.DLL");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
