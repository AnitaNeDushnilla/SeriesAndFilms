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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private bool EditSer = false;

        private SERIES series1 = new SERIES();
        public AddEditPage()
        {
            InitializeComponent();
        }
        public AddEditPage(SERIES series)
        {
            InitializeComponent();
            series1 = series;
            tbTitle.Text = "Изменить сериал";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Добавить сериал?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                SERIES ser = new SERIES();

                ser.SeriesName = tbxName.Text;
                ser.Description = tbxDecp.Text;

                

                AppData.context.SERIES.Add(ser);
                AppData.context.SaveChanges();
            }
            MessageBox.Show("Сериал добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigateClass.frame.Navigate(new Pages.SeriesPage());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frame.GoBack();
        }
    }

 }

