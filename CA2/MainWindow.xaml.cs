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
            FullTimeEmployee ft1 = new FullTimeEmployee("Joe", "Murphy", "Full Time", 24000);
            PartTimeEmployee pt2 = new PartTimeEmployee("John", "Smith", "Part Time", 15, 14);
            FullTimeEmployee ft2 = new FullTimeEmployee("Jess", "Walsh", "Full Time", 25000);

            employees.Add(pt1);
            employees.Add(ft1);
            employees.Add(pt2);
            employees.Add(ft2);

            listBox.ItemsSource = employees;
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxFirstName.Clear();
            textBoxSurname.Clear();
            textBoxSalary.Clear();
            textBoxHourlyRate.Clear();
            textBoxHoursWorked.Clear();
            radioButtonPT.IsChecked = false;
            radioButtonFT.IsChecked = false;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PartTimeEmployee selectedPT = listBox.SelectedItem as PartTimeEmployee;
            FullTimeEmployee selectedFT = listBox.SelectedItem as FullTimeEmployee;

            if (selectedPT != null)
            {
                textBoxFirstName.Text = selectedPT.FirstName;
                textBoxSurname.Text = selectedPT.LastName;
                textBoxSalary.Clear();
                textBoxHourlyRate.Text = selectedPT.HourlyRate.ToString();
                textBoxHoursWorked.Text = selectedPT.HoursWorked.ToString();
                radioButtonPT.IsChecked = true;
                radioButtonFT.IsChecked = false;
            }

            if (selectedFT != null)
            {
                textBoxFirstName.Text = selectedFT.FirstName;
                textBoxSurname.Text = selectedFT.LastName;
                textBoxSalary.Text = selectedFT.Salary.ToString();
                textBoxHourlyRate.Clear();
                textBoxHoursWorked.Clear();
                radioButtonPT.IsChecked = false;
                radioButtonFT.IsChecked = true;
            }
        }
    }
}
