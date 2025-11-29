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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Comapison.xaml
    /// </summary>
    public partial class Comapison : Page
    {
        public List<View_1> view { get; set; } = new List<View_1>();
        public Comapison()
        {
            InitializeComponent();
            DataContext = this;
            LoadView();
            // Используем глобальное хранилище тарифов для сравнения
            // Это ObservableCollection, поэтому UI автоматически обновится при изменении
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppConnect.frame.Navigate(new Calculator());
        }

        private void OrderTariff_Click(object sender, RoutedEventArgs e)
        {
            // Получаем тариф из DataContext элемента
            if (sender is Button button)
            {
                // DataContext кнопки устанавливается автоматически через DataTemplate
                if (button.DataContext is View_1 tariff)
                {
                    MessageBox.Show($"Оформление тарифа \"{tariff.name}\".", "Заказ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public void LoadView()
        {
            view.Clear();
            try
            {
                using (var db = new cellServiceEntities())
                {
                    foreach (var ads in db.View_1.OrderBy(t => t.idTariffs).ToList())
                    {
                        view.Add(ads);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить представление: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
