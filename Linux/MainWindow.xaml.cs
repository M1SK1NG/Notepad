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
using System.Windows.Threading;

namespace Linux
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Class1 bloknot;
        public MainWindow()
        {
            InitializeComponent();
            bloknot = new Class1(Rich1);
        }
        DispatcherTimer timer;
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm:ss");
            data.Text = d.ToString("dd:MM:yyyy");
        }
        private void CreateS_Click(object sender, RoutedEventArgs e)
        {
            bloknot.Create();
            this.Title = bloknot.NameFile;
        }
        private void Rich1_TextChanged(object sender, TextChangedEventArgs e)
        {
            bloknot.Modified=true;
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            
            bloknot.OpenFile();
            this.Title=bloknot.NameFile;
        }
        private void EXTS_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ASSAve_Click(object sender, RoutedEventArgs e)
        {
            bloknot.ASaveBloknot();
            this.Title = bloknot.NameFile;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (bloknot.Modified == true)
                bloknot.Save();
            this.Title = bloknot.NameFile;

        }
        private void copy_Click(object sender, RoutedEventArgs e)
        {
            Rich1.Copy();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (bloknot.Modified == true)
            {
                MessageBoxResult result;
                result = MessageBox.Show("Вы желаете сохранить файл?", "Блокнот", MessageBoxButton.YesNoCancel,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    if (bloknot.ASaveBloknot() == false) return;


                if (result == MessageBoxResult.Cancel) return;

            }
            else
            {

            }

        }
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            Rich1.Paste();
        }
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            Rich1.Cut();
        }
        private void NewWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
        }
        private void remove_Click(object sender, RoutedEventArgs e)
        {

            Rich1.Selection.Text = "";
        

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Rich1.Undo();
        }
        private void AllSelect_Click(object sender, RoutedEventArgs e)
        {
            Rich1.SelectAll();
        }
        private void Time_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Дата:" + DateTime.Now.ToShortDateString()+ "\n " +"Актуальное время:" + DateTime.Now.ToLongTimeString());
        }
        private void Fat_Click(object sender, RoutedEventArgs e)
        {

            object temp = Rich1.Selection.GetPropertyValue(Inline.FontWeightProperty);
            if (temp != DependencyProperty.UnsetValue && temp.Equals(FontWeights.Normal))
            {
                Rich1.Selection.ApplyPropertyValue(Inline.FontWeightProperty,FontWeights.Bold);

            }
            else
            {
                Rich1.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);
            }

        }
        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            object temp = Rich1.Selection.GetPropertyValue(Inline.FontStyleProperty);
            if (temp != DependencyProperty.UnsetValue && temp.Equals(FontStyles.Normal))
            {
                Rich1.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);

            }
            else
            {
                Rich1.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
            }
        }
        private void UnderLine_Click(object sender, RoutedEventArgs e)
        {
            if (Rich1.Selection.GetPropertyValue(Inline.TextDecorationsProperty) != TextDecorations.Underline)
            {
                Rich1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);

            }
            else
            {
                Rich1.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }   
        }
        private void DeleteLine_Click(object sender, RoutedEventArgs e)
        {
            bloknot.DeleteThisLine();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bing.com/search?q=%d1%81%d0%bf%d1%80%d0%b0%d0%b2%d0%ba%d0%b0+%d0%bf%d0%be+%d0%b8%d1%81%d0%bf%d0%be%d0%bb%d1%8c%d0%b7%d0%be%d0%b2%d0%b0%d0%bd%d0%b8%d1%8e+%d0%b1%d0%bb%d0%be%d0%ba%d0%bd%d0%be%d1%82%d0%b0+%d0%b2+windows%c2%a010&filters=guid:%224466414-ru-dia%22%20lang:%22ru%22&form=T00032&ocid=HelpPane-BingIA");
        }
        private void NextPose_Click(object sender, RoutedEventArgs e)
        {
            bloknot.FollowingPose();
        }
        private void StatusBars_Click(object sender, RoutedEventArgs e)
        {
            if (Status.Visibility == Visibility.Visible)
            {
                Status.Visibility = Visibility.Hidden;
                Rich1.Margin = new Thickness(0, 18, 0, 22);
            }
            else
            {
                Status.Visibility = Visibility.Visible;
                Rich1.Margin = new Thickness(0, 18, 0, 22);
            }
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработал программу блокнот:\nСтудент группы:ИСП-31\nЛейбович Михаил\nЗадание: Разработать блокнот\nДоп.Задание по варианту №2:\n1)Перейти в новую позицию.\n2)Удалить текущую строку.\n\nЗащещено не авторскими правми©");
        }
    }
}
