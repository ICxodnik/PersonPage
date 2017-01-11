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
        const string StatusRegist = "Регистрация выполнена успешно";
        const string AgainRegist = "Зарегистрировать нового пользователя";
        const string Regist = "Зарегистрироваться";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = context;
        }

        private void btImageList_Click(object sender, RoutedEventArgs e)
        {
            var imageSource = new VistaOpenFileDialog();
            imageSource.Filter = "Image|*.png;*.jpg;*.bmp";
            var dialogResult = imageSource.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                var choosedFolder = imageSource.FileName;
                context.ImageLink = choosedFolder;
            }
        }

        private void btRegist_Click(object sender, RoutedEventArgs e)
        {
            if (btHavRegist.Content == StatusRegist)
            {
                System.Threading.Thread.Sleep(150);
                NewRegist();
            }
            else
            {
                if (context.Error == "")
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
                    btHavRegist.Content = StatusRegist;
                    btHavRegist.Visibility = Visibility.Visible;
                    btRegist.Content = AgainRegist;
                }
                else
                {
                    btHavRegist.Content = context.Error;
                    btHavRegist.Visibility = Visibility.Visible;
                }
            }
        }

        private void NewRegist()
        {
            if (btHavRegist.Content == StatusRegist)
            {
                context = new MainDataContext();
                this.DataContext = context;
                comboBox.SelectedIndex = (int)SexType.Men;
                btHavRegist.Content = "";
                btRegist.Content = Regist;
                btHavRegist.Visibility = Visibility.Hidden;
            }
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) ) e.Handled = true;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(150);
            NewRegist();
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void txName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (context["Name"] != "")
            {
                txName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F18E2F4A"));
            }
            else
            {
                txName.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#55FFFFFF"));
            }
        }

        private void txName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (context["Age"] != "")
            {
                txAge.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F18E2F4A"));
            }
            else
            {
                txAge.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#55FFFFFF"));
            }
        }


        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((SexType)comboBox.SelectedIndex == SexType.Men)
            {
                context.ImageLink = "Image\\User.png";
            }
            if ((SexType)comboBox.SelectedIndex == SexType.Women)
            {
                context.ImageLink = "Image\\UserW.png";
            }
        }
    }
}
