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
        public string Status { get; set; }

        public Employee()
        {

        }

        public Employee(string FirstName, string LastName, string Status)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Status = Status;
        }

        public abstract decimal CalculateMonthlyPay();

        public override string ToString()
        {
            return string.Format($"{LastName.ToUpper()}, {FirstName} - {Status}");
        }
    }


    public class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }

        public FullTimeEmployee(string FirstName, string LastName, string Status, decimal Salary) : base(FirstName, LastName, Status)
        {
            this.Salary = Salary;
        }

        public override decimal CalculateMonthlyPay()
        {
            return Salary / 12;
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()} Salary {Salary}");
        }

    }


    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public double HoursWorked { get; set; }

        public PartTimeEmployee(string FirstName, string LastName, string Status, decimal HourlyRate, double HoursWorked) : base(FirstName, LastName, Status)
        {
            this.HourlyRate = HourlyRate;
            this.HoursWorked = HoursWorked;
        }

        public override void CalculateMonthlyPay()
        {
            //HourlyRate * HoursWorked;
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()} Hourly Rate {HourlyRate} Hours Worked {HoursWorked}");
        }

    }
}
