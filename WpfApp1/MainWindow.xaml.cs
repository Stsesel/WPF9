using Microsoft.Win32;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}

        private void ComboBox_SelectionChanged1 (object sender, SelectionChangedEventArgs e)
        {
            //string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (textBox != null)
            {
                textBox.FontFamily = new FontFamily(fontName);

            }
    
        }

        //Размер шрифта

        private void ComboBox_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            
            if (textBox != null)
            {
                //double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
                double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as string));
                textBox.FontSize = fontSize;
            }
        }

        //Жирный шрифт

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if (textBox.FontWeight == FontWeights.Normal)
            {
                textBox.FontWeight = FontWeights.Bold;

            }
            else
            {
                textBox.FontWeight = FontWeights.Normal;
            }
        }

        //Наклонный шрифт

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (textBox.FontStyle == FontStyles.Normal)
            {
                textBox.FontStyle = FontStyles.Italic;

            }
            else
            {
                textBox.FontStyle = FontStyles.Normal;
            }
        }

        //Подчеркнтый шрифт

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations.Count == 0)  
            {
                textBox.TextDecorations.Add(TextDecorations.Underline);
            }
            else
            {
                textBox.TextDecorations.RemoveAt(0);
            }
        }



        //Радиокнопки

        private void Black_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Black;
            }
           
        }

        private void Green_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Green;
            }

        }

        private void Yellow_Checked(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
            {
                textBox.Foreground = Brushes.Blue;
            }

        }








        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName,textBox.Text);
            }
        }

        //private void MenuItem_Click3(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void themes_SelectionChanges(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Uri theme = new Uri(themes.SelectedIndex == 0 ? "Light.xaml" : "Dark.xaml", UriKind.Relative);
            ResourceDictionary themeDict = Application.LoadComponent(theme) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(themeDict);
        }





        //private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        textBox.Text = File.ReadAllText(openFileDialog.FileName);
        //    }
        //}

        //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        textBox.Text = File.ReadAllText(openFileDialog.FileName);
        //    }

        //}
    }

}
