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
        ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PartTimeEmployee pt1 = new PartTimeEmployee("Jane", "Jones", "Part Time", 10, 15);
            PartTimeEmployee pt2 = new PartTimeEmployee("John", "Smith", "Part Time", 15, 14);
            FullTimeEmployee ft1 = new FullTimeEmployee("Joe", "Murphy", "Full Time", 24000);
            FullTimeEmployee ft2 = new FullTimeEmployee("Jess", "Walsh", "Full Time", 25000);

            employees.Add(pt1);
            employees.Add(ft1);
            employees.Add(pt2);
            employees.Add(ft2);

            //listBox.ItemsSource = employees;
        }

        public void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxFirstName.Clear();
            textBoxSurname.Clear();
            textBoxSalary.Clear();
            textBoxHourlyRate.Clear();
            textBoxHoursWorked.Clear();
            textBlockMonthlyPay.Text = "";
            radioButtonPT.IsChecked = false;
            radioButtonFT.IsChecked = false;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PartTimeEmployee selectedPT = listBox.SelectedItem as PartTimeEmployee;
            FullTimeEmployee selectedFT = listBox.SelectedItem as FullTimeEmployee;
            Employee selectedEmployee = (Employee)listBox.SelectedItem;

            if (selectedPT != null)
            {
                textBoxFirstName.Text = selectedPT.FirstName;
                textBoxSurname.Text = selectedPT.LastName;
                textBoxSalary.Clear();
                textBoxHourlyRate.Text = selectedPT.HourlyRate.ToString();
                textBoxHoursWorked.Text = selectedPT.HoursWorked.ToString();
                textBlockMonthlyPay.Text = selectedEmployee.CalculateMonthlyPay().ToString();
                radioButtonPT.IsChecked = true;
                radioButtonFT.IsChecked = false;
            }

            else if (selectedFT != null)
            {
                textBoxFirstName.Text = selectedFT.FirstName;
                textBoxSurname.Text = selectedFT.LastName;
                textBoxSalary.Text = selectedFT.Salary.ToString();
                textBlockMonthlyPay.Text = selectedEmployee.CalculateMonthlyPay().ToString();
                textBoxHourlyRate.Clear();
                textBoxHoursWorked.Clear();
                radioButtonPT.IsChecked = false;
                radioButtonFT.IsChecked = true;
            }
        }

        // Not Working
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = textBoxFirstName.Text;
            string Surname = textBoxSurname.Text;

            if (radioButtonFT.IsChecked == true)
            {
                decimal Salary = Convert.ToDecimal(textBoxSalary.Text);

                FullTimeEmployee FTEmployee = new FullTimeEmployee(FirstName, Surname, "Full Time", Salary);
                employees.Add(FTEmployee);
            }

            else if (radioButtonPT.IsChecked == true)
            {
                decimal HourlyRate = Convert.ToDecimal(textBoxHourlyRate.Text);
                double HoursWorked = Convert.ToDouble(textBoxHoursWorked.Text);

                PartTimeEmployee PTEmployee = new PartTimeEmployee(FirstName, Surname, "Part Time", HourlyRate, HoursWorked);
                employees.Add(PTEmployee);
            }
            Filter();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = (Employee)listBox.SelectedItem;
            employees.Remove(selectedEmployee);

            // After selected employee is deleted - All info is cleared from the textboxes/ blocks
            textBoxFirstName.Clear();
            textBoxSurname.Clear();
            textBoxSalary.Clear();
            textBoxHourlyRate.Clear();
            textBoxHoursWorked.Clear();
            textBlockMonthlyPay.Text = "";
            radioButtonPT.IsChecked = false;
            radioButtonFT.IsChecked = false;

            Filter();
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void Filter()
        {
            filteredEmployees.Clear();
            listBox.ItemsSource = null;

            if (checkBoxPT.IsChecked == true)
            {

                foreach (Employee employee in employees)
                {
                    if (employee is PartTimeEmployee)
                    {
                        filteredEmployees.Add(employee);
                    }
                }
                listBox.ItemsSource = filteredEmployees;

            }


            if (checkBoxFT.IsChecked == true)
            {

                foreach (Employee employee in employees)
                {
                    if (employee is FullTimeEmployee)
                    {
                        filteredEmployees.Add(employee);
                    }
                }
                listBox.ItemsSource = filteredEmployees;

            }

            if (checkBoxFT.IsChecked == false && checkBoxPT.IsChecked == false)
            {
                foreach (Employee employee in employees)
                {
                    if (employee is Employee)
                    {
                        filteredEmployees.Add(employee);
                    }
                }
                listBox.ItemsSource = filteredEmployees;
            }
        }
    }
}