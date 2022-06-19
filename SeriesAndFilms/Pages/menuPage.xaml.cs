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
using SeriesAndFilms.Pages;
using SeriesAndFilms.ClassHelper;

namespace SeriesAndFilms.Pages
{
    /// <summary>
    /// Логика взаимодействия для menuPage.xaml
    /// </summary>
    public partial class menuPage : Page
    {
        public menuPage()
        {
            InitializeComponent();
        }

        private void btnMainPage_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Content = null;
        }

        private void btnFilms_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new FilmPage());
        }

        private void btnSeries_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new SeriesPage());
        }
    }
}
