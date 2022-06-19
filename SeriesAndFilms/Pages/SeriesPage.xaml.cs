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
    /// Логика взаимодействия для SeriesPage.xaml
    /// </summary>
    public partial class SeriesPage : Page
    {
        List<SERIES> series = new List<SERIES>();
        public SeriesPage()
        {
            InitializeComponent();
            GetList();
        }
        public void GetList()
        {
            series = AppData.context.SERIES.ToList();
            lvSeries.ItemsSource = series;
        }
        private void DeleteItem()
        {
            if (lvSeries.SelectedItem is SERIES)
            {
                var srDel = lvSeries.SelectedItem as SERIES;
                AppData.context.SERIES.Remove(srDel);
                AppData.context.SaveChanges();
                GetList();
            }
            else
            {
                MessageBox.Show("Поле не выбрано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            var res = MessageBox.Show("Удалить сериал?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res != MessageBoxResult.Yes)
            {
                return;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.Navigate(new AddEditPage());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteItem();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var srEdit = lvSeries.SelectedItem as SERIES;
            NavigateClass.frame.Navigate(new AddEditPage(srEdit));
        }

        private void lvSeries_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteItem();
            }
        }

        private void lvSeries_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
