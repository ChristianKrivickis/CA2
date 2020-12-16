using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public abstract class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract void CalculateMonthlyPay();



        public Employee()
        {

        }

        public Employee(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName}");
        }
    }


    public class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public override void CalculateMonthlyPay()
        {
            Salary = Salary / 12;
        }

    }


    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public override void CalculateMonthlyPay()
        {
            //HourlyRate * HoursWorked;
        }
    }
}
