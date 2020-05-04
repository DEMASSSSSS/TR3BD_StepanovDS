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
using System.Windows.Shapes;
using GameProj.View;

namespace GameProj
{
    public partial class AddWindow : Window
    {
        private readonly int _currentTab;

        public AddWindow(int tab)
        {
            InitializeComponent();
            _currentTab = tab;
            ComboBox.SelectedIndex = 0;
            ShowDataGrid();
        }

        private void ShowDataGrid()
        {
            switch (_currentTab)
            {
                case 1:
                    ProjDataGrid.Visibility = Visibility.Visible;
                    WindowAdd.Title = "Данные по проектам";
                    break;
                case 2:
                    SalaryDataGrid.Visibility = Visibility.Visible;
                    ComboBox.Visibility = Visibility.Visible;
                    WindowAdd.Title = "Сортировка по языку";
                    break;
                case 3:
                    SortRateDataGrid.Visibility = Visibility.Visible;
                    WindowAdd.Title = "Сортировка по рейтингу";
                    break;
            }
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var view = new ViewAdditional(ComboBox.SelectedValue.ToString());
            SalaryDataGrid.ItemsSource = view.ItemsDevSalary;
        }
    }
}
