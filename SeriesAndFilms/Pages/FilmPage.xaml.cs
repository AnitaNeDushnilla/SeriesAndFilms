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
using SeriesAndFilms.ClassHelper;
using SeriesAndFilms.EF;


namespace SeriesAndFilms.Pages
{
    /// <summary>
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        List <FILMS> films = new List<FILMS>();
        public FilmPage()
        {
            InitializeComponent();
            GetList();
        }
        public void GetList()
        {
            films = AppData.context.FILMS.ToList();
            lvFilms.ItemsSource = films;
        }
        private void DeleteItem()
        {
            if (lvFilms.SelectedItem is FILMS)
            {
                var filmDel = lvFilms.SelectedItem as FILMS;
                AppData.context.FILMS.Remove(filmDel);
                AppData.context.SaveChanges();
                GetList();
            }
            else
            {
                MessageBox.Show("Поле не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var res = MessageBox.Show("Удалить фильм?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res != MessageBoxResult.Yes)
            {
                return;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem();
        }

        private void lvFilms_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteItem();
            }
        }

        private void lvFilms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
