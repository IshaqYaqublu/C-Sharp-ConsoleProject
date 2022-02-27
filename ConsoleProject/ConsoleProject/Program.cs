using System;
using ConsoleProject.Models;
using ConsoleProject.Services;
using ConsoleProject.InterFace;


namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {


            ConsoleProjectService consoleProjectService = new ConsoleProjectService();

            do
            {

                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Zehmet olmasa seçim edin.");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("1 *Department yaradin*");
                Console.WriteLine("2 *Elave olunan Departmentler*");
                Console.WriteLine("3 *Departmentde desiklik edin*");
                Console.WriteLine("4 *Isci yaradin*");
                Console.WriteLine("5 *Iscide deyisiklik edin*");
                Console.WriteLine("6 *Elave olunan isciler*");
                Console.WriteLine("7 *Departmentden iscini silin*");
                Console.WriteLine("8 *Axtaris edin.*");
                Console.WriteLine("9 *Sistemden cixis edin.*");

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


                string str = Console.ReadLine();
                int choose;

                while (!int.TryParse(str, out choose) || choose < 1 || choose > 9)
                {
                    Console.WriteLine("Zehmet olmasa duzgun secim edin!");
                    str = Console.ReadLine();
                }

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        AddDepartment(ref consoleProjectService);
                        break;
                    case 2:
                        Console.Clear();
                        GetDepartments(ref consoleProjectService);
                        break;
                    case 3:
                        Console.Clear();
                        EditDepartments(ref consoleProjectService);
                        break;
                    case 4:
                        Console.Clear();
                        AddEmployee(ref consoleProjectService);
                        break;
                    case 5:
                        Console.Clear();
                        EditEmployee(ref consoleProjectService);
                        break;
                    case 6:
                        Console.Clear();
                        GetEmployees(ref consoleProjectService);
                        break;
                    case 7:
                        Console.Clear();
                        RemoveEmployee(ref consoleProjectService);
                        break;
                    case 8:
                        Console.Clear();
                        FindEmployee(ref consoleProjectService);
                        break;
                    case 9:
                        Console.WriteLine("*Sistemden cixdiniz.*");
                        Console.ReadLine();
                        return;
                }

            } while (true);
        }


        static void AddDepartment(ref ConsoleProjectService consoleProjectService)
        {
            Console.WriteLine("Department adini daxil edin :");
            string departmentName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(departmentName))
            {
                Console.WriteLine("Duzgun daxil edin.!");
                departmentName = Console.ReadLine();
            }

            Console.WriteLine("Isci limitini daxil edin:");
            string limit = Console.ReadLine();
            int employeeLimit;

            while (!int.TryParse(limit, out employeeLimit) || employeeLimit < 1 || employeeLimit > 30)
            {
                Console.WriteLine("Duzgun limitn daxil edin.!");
                limit = Console.ReadLine();
            }

            Console.WriteLine("Isci maasini daxil edin :");
            string salary = Console.ReadLine();
            double salaryLimit;

            while (!double.TryParse(salary, out salaryLimit) || salaryLimit < 250)
            {
                Console.WriteLine("Daxil etdiyiniz maas miqdari asagidir, tekrar daxil edin.");
                salary = Console.ReadLine();
            }

            consoleProjectService.AddDepartment(departmentName, employeeLimit, salaryLimit);

            Console.WriteLine($" {departmentName} Adinda Department yaradildi.");
        }
        static void GetDepartments(ref ConsoleProjectService consoleProjectService)
        {
            if (consoleProjectService.Departments.Length > 0)
            {

                foreach (Department department in consoleProjectService.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("*Zehmet olmasa birinci Department yaradin*");

            }
        }
        public static void EditDepartments(ref ConsoleProjectService consoleProjectService)
        {
            if (consoleProjectService.Departments.Length > 0)
            {
                foreach (Department department in consoleProjectService.Departments)
                {
                    Console.WriteLine(department);
                }

            }
            else
            {
                Console.WriteLine("Evvelce department yaradin.!");
            }
            Console.WriteLine("Evvelki department adini daxil edin");
            string oldName = Console.ReadLine();
            Console.WriteLine("Yeni department adini daxil edin");
            string newName = Console.ReadLine();

            consoleProjectService.EditDepartments(oldName, newName);
            Console.WriteLine("Department adi ugurla deyisdirildi:");
        }
        private static void AddEmployee(ref ConsoleProjectService consoleProjectService)
        {
            if (consoleProjectService.Departments.Length > 0)
            {

                foreach (Department department in consoleProjectService.Departments)
                {
                    Console.WriteLine(department);
                }
            }
            else
            {
                Console.WriteLine("Evvelce Department yaradin");

            }


            Console.WriteLine("Department adini daxil edin");
            string departmentName = Console.ReadLine();
            Console.WriteLine("Iscinin adini daxil et");
            string employeeFullName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(employeeFullName))
            {
                Console.WriteLine("Duzgun ad daxil edin.!");
                employeeFullName = Console.ReadLine();
            }

            Console.WriteLine("Vezifesini daxil edin");
            string employeePosition = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(employeePosition))
            {
                Console.WriteLine("Duzgun vezife daxil et.!");
                employeePosition = Console.ReadLine();
            }

            Console.WriteLine("Maasini daxil edin.");
            string employeeSalary = Console.ReadLine();
            double checkSalary;

            while (!(double.TryParse(employeeSalary, out checkSalary)) || checkSalary < 250)
            {
                Console.WriteLine("Duzgun maas daxil edin.!");
                employeeSalary = Console.ReadLine();
            }

            consoleProjectService.AddEmployee(employeeFullName, employeePosition, checkSalary, departmentName);


        }
        public static void GetEmployees(ref ConsoleProjectService consoleProjectService)
        {
            foreach (var item in consoleProjectService.Departments)
            {
                foreach (var employee in item.GetEmployees())
                {
                    Console.WriteLine(employee);
                }
                
            }
        }
        static void RemoveEmployee(ref ConsoleProjectService consoleProjectService)
        {
            if (consoleProjectService.Departments.Length > 0)
            {
                foreach (var item in consoleProjectService.Departments)
                {
                    foreach (var employee in item.GetEmployees())
                    {
                        Console.WriteLine(employee);
                    }
                }

                Console.WriteLine("Department adini daxil edin.");
                string departmentName = Console.ReadLine();
                Console.WriteLine("Isci nomresini daxil edin");
                string removeEmployee = Console.ReadLine();
                consoleProjectService.RemoveEmployee(removeEmployee, departmentName);
            }
            else
            {
                Console.WriteLine("Evvelce Deparment yaradin");
            }
        }

        static void FindEmployee(ref ConsoleProjectService consoleProjectService)
        {
            if (consoleProjectService.Departments.Length > 0)
            {
                Console.WriteLine("Department adini daxil edin.");

            }
            else
            {
                Console.WriteLine("Evvelce Deparment yarat");
            }
            string departmentsName = Console.ReadLine();

            if (consoleProjectService.FindEmployee(departmentsName) != null)
            {
                foreach (Employee employee in consoleProjectService.FindEmployee(departmentsName))
                {
                    if (employee != null)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            else
            {
                Console.WriteLine("Department movcud deyil");
            }

        }
        static void EditEmployee(ref ConsoleProjectService consoleProjectService)
        {
            if (consoleProjectService.Departments.Length > 0)
            {
                foreach (var item in consoleProjectService.Departments)
                {
                    foreach (var employee in item.GetEmployees())
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            else
            {
                Console.WriteLine("Evvelce Deparment yaradin.!");
            }


            Console.WriteLine("Iscinin nomresini daxil edin");
            string empNum = Console.ReadLine();
            Console.WriteLine("Yeni vezifeni daxil edin");
            string newPos = Console.ReadLine();
            Console.WriteLine("Yeni maas daxil et");
            double newSalary;
            double.TryParse(Console.ReadLine(), out newSalary);
            Console.WriteLine("Department adini daxil edin");
            string depName = Console.ReadLine();





            consoleProjectService.EditEmployee(empNum, newPos, newSalary, depName);

        }
    }
}
