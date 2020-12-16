using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2
{

    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>(); 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PartTimeEmployee pt1 = new PartTimeEmployee("Jane", "Jones", "Part Time", 10, 15);
            PartTimeEmployee pt2 = new PartTimeEmployee("John", "Smith", "Part Time", 10, 15);


            employees.Add(pt1);
            employees.Add(pt2);

            listBox.ItemsSource = employees;
        }
    }
}
