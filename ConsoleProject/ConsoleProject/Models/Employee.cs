using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject.Models;

namespace ConsoleProject.Models
{
    class Employee
    {
        private Employee[] employees;
       
        private static int _count = 1000;
        public string No { get; set; }
        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                while (!CheckFullName(value))
                {
                    Console.WriteLine("Duzgun ad daxil edin.!");
                    value = Console.ReadLine();
                }
                _fullName = value;
            }
        }

        private static double _salary;
        private string _position;
        public string Position
        {
            get => _position;
            set
            {
                while (!CheckPosition(value))
                {
                    Console.WriteLine("Duzgun vezife daxil edin.!");
                    value = Console.ReadLine();
                }
                _position = value;
            }
        }
        public static double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                while (!CheckSalary(value))
                {
                    Console.WriteLine("Maas limiti duzgun deyil.");
                    Console.WriteLine("Mass limitini duzgun daxil edin.!");
                    double.TryParse(Console.ReadLine(), out value);
                }
                _salary = value;
            }
        }
        public string DepartmentName { get; set; }


        public Employee(string fullName, string position, double salary, string departmentName)
        {
            FullName = fullName;
            Position = position;
            Salary = salary;
            _count++;
            DepartmentName = departmentName;
            
            No = $"{DepartmentName[0..2].ToUpper()}{_count}";
        }

        public override string ToString()
        {
            return $"Ad ve Soyad-- {FullName} \nVezife-- " +
                $"{Position} \nMaas-- {Salary} \nDepartmentin adi-- " +
                $"{DepartmentName}\n" +
                $"Iscinin nomresi--{No}";
        }

        public static bool CheckSalary(double salary)
        {
            return salary >= 250 ? true : false;
        }
        public bool CheckPosition(string position)
        {
            return position.Length >= 2 ? true : false;
        }
        public bool CheckFullName(string fullName)
        {
            int count = 0;
            for (int i = 0; i < fullName.Length; i++)
            {
                if (char.IsUpper(fullName[i]) && i == 0)
                {
                    count++;
                }
                else if (char.IsWhiteSpace(fullName[i]))
                {
                    count++;
                    if (char.IsUpper(fullName[i + 1]))
                    {
                        count++;
                    }
                }
            }
            if (count == 3)
            {
                return true;
            }
            return false;

        }
        
    }
}
