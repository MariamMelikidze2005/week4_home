
namespace tack;
using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public decimal Hsalary { get; set; }
    public TimeSpan HoursWorked { get; set; } = TimeSpan.Zero;

    public Employee(string name, decimal hsalary, TimeSpan hoursWorked)
    {
        Name = name;
        Hsalary = hsalary;
        HoursWorked = hoursWorked;
    }
}

public class Program
{
    public static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee("Domeniko", 15.5m, new TimeSpan(10, 0, 0)),
            new Employee("Zebuloni", 10.5m, new TimeSpan(6, 30, 0))
        };
        List<Employee> overtimeEmployees = GetOvertimeEmployees(employees);
        Console.WriteLine("Employees who worked overtime and payment:");
        TimeSpan overtime = new TimeSpan(8, 0, 0);

        foreach (var employee in overtimeEmployees)
        {
            decimal totalAmount = CalculateTotalAmount(employee, overtime);
            Console.WriteLine($"{employee.Name} worked {employee.HoursWorked.TotalHours} hours. Total payment: {totalAmount}.");
        }
    }
    private static List<Employee> GetOvertimeEmployees(List<Employee> employees)
    {
        List<Employee> overtimeEmployees = new List<Employee>();
        TimeSpan overtimehold = new TimeSpan(8, 0, 0);

        foreach (var employee in employees)
        {
            if (employee.HoursWorked > overtimehold)
            {
                overtimeEmployees.Add(employee);
            }
        }

        return overtimeEmployees;
    }

    private static decimal CalculateTotalAmount(Employee employee, TimeSpan overtimeThreshold)
    {
        if (employee.HoursWorked > overtimeThreshold)
        {
            TimeSpan overtimeHours = employee.HoursWorked - overtimeThreshold;

            decimal regular = (decimal)overtimeThreshold.TotalHours;
            decimal DecimalHours = (decimal)overtimeHours.TotalHours;

            decimal overtimeAmount = DecimalHours * employee.Hsalary * 1.25m; 
            decimal regularA = regular * employee.Hsalary; 

            return regularA + overtimeAmount; 
        }
        else
        {
            decimal regularAmount = (decimal)employee.HoursWorked.TotalHours * employee.Hsalary;
            return regularAmount;
        }
    }
}
