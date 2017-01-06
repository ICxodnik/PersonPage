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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ookii.Dialogs.Wpf;
using System.IO;

namespace PersonPage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainDataContext context = new MainDataContext();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btImageList_Click(object sender, RoutedEventArgs e)
        {
            var imageChoose = new VistaOpenFileDialog();
            var dialogResult = imageChoose.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                var choosedFolder = imageChoose.FileName;
                if (Directory.Exists(choosedFolder))
                {
                    context.ImageLink = choosedFolder;
                }
            }
        }

        private void btRegist_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
