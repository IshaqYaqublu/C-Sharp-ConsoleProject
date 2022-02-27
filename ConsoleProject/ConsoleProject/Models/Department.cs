using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject.InterFace;


namespace ConsoleProject.Models
{
    class Department
    {

        private double _salaryLimit;
        private string _name;
        private int _employeeLimit;
        private Employee[] Employees;

        public string Name
        {
            get => _name;
            set
            {
                while (!(value.Length >= 2))
                {
                    Console.WriteLine("Department ad iki herfden cox olmalidir.!");
                    value = Console.ReadLine();

                }
                _name = value;
            }
        }



        public int WorkerLimit
        {
            get => _employeeLimit;
            set
            {
                while (!(value >= 1))
                {
                    Console.WriteLine("Isci limitini duzgun daxil edin");
                    int.TryParse(Console.ReadLine(), out value);

                }

                _employeeLimit = value;
            }
        }
        public double SalaryLimit
        {
            get => _salaryLimit;

            set
            {
                if (value < 250)
                {
                    Console.WriteLine("Maasi duzgun daxil edin");

                    while (!double.TryParse(Console.ReadLine(), out value) && value < 250)
                    {
                        Console.WriteLine("Maasi duzgun daxil edin");
                        double.TryParse(Console.ReadLine(), out value);
                    }
                }
                _salaryLimit = value;

            }
        }


        public Department(string name, int employeeLimit, double salaryLimit)
        {
            Employees = new Employee[0];
            Name = name;
            WorkerLimit = employeeLimit;
            SalaryLimit = salaryLimit;
            
        }

        public Employee[] GetEmployees() => Employees;


        public override string ToString()
        {
            return $"Departmentin adi: {Name}\n Verilen Maas Limiti:{SalaryLimit}\nIsci limiti: {WorkerLimit}";
        }


        public void AddEmployee(Employee employee)
        {
            if (Employees.Length < WorkerLimit)
            {
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[Employees.Length - 1] = employee;
            }
            else
            {
                Console.WriteLine("Departmentde yer yoxdur");
            }
        }

        public void RemoveEmployee(string departmentName, string no)
        {
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i] != null && Employees[i].No == no && Employees[i].DepartmentName == departmentName)
                {
                    Employees[i] = null;
                    return;
                }
            }
        }

        
    } 
}
