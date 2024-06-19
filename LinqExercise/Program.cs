using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise;

class Program
{
    //Static array of integers
    private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

    static void Main(string[] args)
    {
        /*
         * 
         * Complete every task using Method OR Query syntax. 
         * You may find that Method syntax is easier to use since it is most like C#
         * Every one of these can be completed using Linq and then printing with a foreach loop.
         * Push to your github when completed!
         * 
         */

        //TODO: Print the Sum of numbers
        Console.WriteLine($"Sum: {numbers.Sum()}");   //method syntax
        /*(from num in numbers                              //query syntax
         select num).Sum();*/

        //TODO: Print the Average of numbers
        Console.WriteLine($"\nAverage: {numbers.Average()}");   //method syntax
        /*(from num in numbers                                      //query syntax
         select num).Average();*/

        //TODO: Order numbers in ascending order and print to the console
        Console.WriteLine("\nAscending Order:");
        //numbers.OrderBy(x => x);     //method syntax
        (from num in numbers            //query syntax
         orderby num ascending
         select num).ToList().ForEach(num => Console.WriteLine(num));

        //TODO: Order numbers in descending order and print to the console
        Console.WriteLine("\nDescending Order:");
        //numbers.OrderByDescending(x => x);                    //method syntax
        (from num in numbers                                    //query syntax
         orderby num descending
         select num).ToList().ForEach(num => Console.WriteLine(num));

        //TODO: Print to the console only the numbers greater than 6
        Console.WriteLine("\nNumbers greater than 6:");
        //numbers.Where(x => x > 6);     //method syntax
        (from num in numbers            //query syntax
         where num > 6
         select num).ToList().ForEach(num => Console.WriteLine(num));

        //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
        Console.WriteLine("\nDescending (Print 4):");
        //numbers.OrderBy(x => x).Take(4).ToList();   //method syntax
        (from num in numbers                            //query syntax
         orderby num descending
         select num).Take(4).ToList().ForEach(num => Console.WriteLine(num));

        //TODO: Change the value at index 4 to your age, then print the numbers in descending order
        Console.WriteLine("\nChange index 4 to your age, print in descending order: ");
        numbers.SetValue(29, 4);
        //numbers.OrderByDescending(x => x).ToList().ForEach(num => Console.WriteLine(num));  //method syntax
        (from num in numbers                                                                //query syntax
         orderby num descending
         select num).ToList().ForEach(num => Console.WriteLine(num));

        // List of employees ****Do not remove this****
        var employees = CreateEmployees();
        Console.WriteLine("\n-------------------------------------------------------------------\n");

        //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
        Console.WriteLine("\nStarts with C or S in ascending order:");
        employees.Where(x => x.FirstName.StartsWith("C") || x.FirstName.StartsWith("S")).OrderBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine(x.FullName));

        //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
        Console.WriteLine("\nOver the age of 26, ordered by age then firstname");
        employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName).ToList().ForEach(x => Console.WriteLine($"Name: {x.FullName}\tAge: {x.Age}"));
        //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
        Console.WriteLine("\nTotal years of experience if YOE <= 10 && age > 35:");
        Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience));
        //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
        Console.WriteLine("\nAverage of employees' years of experience if YOE <= 10 && age > 35:");
        Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience));
        //TODO: Add an employee to the end of the list without using employees.Add()
        Console.WriteLine("\nAdd new employee and display information:");
        employees = employees.Append(new Employee() { FirstName = "Willy", LastName = "Wonka", Age = 3, YearsOfExperience = 100 }).ToList();
        Console.WriteLine(employees.OrderBy(x => x.Age).First().FullName);
        Console.WriteLine();

        Console.ReadLine();
    }

    #region CreateEmployeesMethod
    private static List<Employee> CreateEmployees()
    {
        List<Employee> employees = new List<Employee>();
        employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
        employees.Add(new Employee("Steven", "Bustamento", 56, 5));
        employees.Add(new Employee("Micheal", "Doyle", 36, 8));
        employees.Add(new Employee("Daniel", "Walsh", 72, 22));
        employees.Add(new Employee("Jill", "Valentine", 32, 43));
        employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
        employees.Add(new Employee("Big", "Boss", 23, 14));
        employees.Add(new Employee("Solid", "Snake", 18, 3));
        employees.Add(new Employee("Chris", "Redfield", 44, 7));
        employees.Add(new Employee("Faye", "Valentine", 32, 10));

        return employees;
    }
    #endregion
}
