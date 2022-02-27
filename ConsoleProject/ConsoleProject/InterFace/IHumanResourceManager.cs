using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject.Models;
using ConsoleProject.InterFace;


namespace ConsoleProject.InterFace
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void GetDepartments(Department[] departments);
        Employee[] GetEmployee(string departmentName);
        Employee[] FindEmployee(string departmentName);
        void AddDepartment(string departmenName, int workerLimit, double salaryLimit);
        void EditDepartments(string departmenName, string newDepartmenName);
        void AddEmployee(string fullName, string position, double salary, string departmentName);
        void EditEmployee(string empNo, string position, double salary, string depName);
        void RemoveEmployee(string no, string departmentName);
        

    }
}
