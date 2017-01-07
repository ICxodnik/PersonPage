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
using PersonPage.DbLayer;

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
            this.DataContext = context;
        }

        private void btImageList_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = context;
            var imageChouse = new VistaOpenFileDialog();
            var dialogResult = imageChouse.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value && imageChouse.CheckFileExists )
            {
                    var choosedFolder = imageChouse.FileName;
                    context.ImageLink = choosedFolder;
            }
        }

        private void btRegist_Click(object sender, RoutedEventArgs e)
        {
            using (DbContex dbContex = new DbContex())
            {
                Person person = new Person()
                {
                    Age = context.Age,
                    ImageLink = context.ImageLink,
                    Name = context.Name,
                    Sex = context.Sex
                };
                dbContex.Persons.Add(person);
                dbContex.SaveChanges();
            }
            btHavRegist.Visibility = Visibility.Visible;
            context = new MainDataContext();
        }


        private void TextBox_TextInput(object sender, RoutedEventArgs e)
        {
            btHavRegist.Visibility = Visibility.Hidden;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

    }
}
