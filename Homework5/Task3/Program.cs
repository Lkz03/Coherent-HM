/*
Task 3. There is information about how employees of a certain organization took vacations
during 2021. This data is presented as a set of objects. Each object stores the name of the
employee, the date of the first day of vacation, the date of the last day of vacation (in the data
set, the names of employees can be repeated - during the year under study, the employee could
go on vacation several times).
1. Create (or use existing) types to represent an individual vacation record and a set of such
records.
2. Implement the following points as separate methods. Try to use LINQ to Objects.
• Find the average length of vacation in the organization.
• Find the average length of vacation for each employee (output the tuples "employee's name
- the average length of his vacation").
• Form and print a set of tuples "number of the month of the year - the number of employees
on vacation this month". Consider that an employee was on vacation in a certain month if he
spent 1 or more days on vacation that month.
• Indicate dates in 2021 on which employees did not take vacations.
• Check the source data for correctness: do they contain such records in which the names of
the employee are the same, and the dates of two holidays intersect.
 */

using Task3.Records;
using Task3.Classes;

public class Program
{
 public static void Main()
 {
  List<EmployeeVacationInformation> list = new List<EmployeeVacationInformation>();

  list.Add(new EmployeeVacationInformation("John", new DateTime(2021, 1, 1), new DateTime(2021, 3, 10)));
  list.Add(new EmployeeVacationInformation("Al", new DateTime(2021, 2, 1), new DateTime(2021, 3, 10)));
  list.Add(new EmployeeVacationInformation("Bob", new DateTime(2021, 3, 10), new DateTime(2021, 5, 10)));
  list.Add(new EmployeeVacationInformation("Al", new DateTime(2021, 3, 1), new DateTime(2021, 6, 1)));
  list.Add(new EmployeeVacationInformation("John", new DateTime(2010, 10, 10), new DateTime(2010, 10, 30)));
  list.Add(new EmployeeVacationInformation("Bob", new DateTime(2021, 3, 12), new DateTime(2021, 4, 30)));
  list.Add(new EmployeeVacationInformation("John", new DateTime(2021, 3, 10), new DateTime(2021, 4, 30)));

  foreach (var item in list)
  {
   Console.WriteLine(item.FirstDayVacation.Month);
  }

  Console.WriteLine($"\nAverage vacaton duration: {VacationInformationTools.GetAverageVacationDuration(list)}\n");

  Console.WriteLine("Average employee's vacation duration:");
  foreach (var item in VacationInformationTools.GetAverageEmployeeVacationDuration(list))
  {
   Console.WriteLine(item);
  }

  Console.WriteLine("\nNumber of employees on vacation during different months:");
  foreach (var item in VacationInformationTools.GetNumberOfEmployeesOnVacationByMonth(list).OrderByDescending(x => x.Item2).ThenBy(x => x.Item1))
  {
   Console.WriteLine($"Count of emplyees: {item.Item2}\nMonth of vacation: {item.Item1}\n");
  }

  Console.WriteLine("Dates of 2021 when no vacations took place:");
  var listOfDatesOfWhenNoVacationsTookPlaceIn2021 = VacationInformationTools.GetMonthsWhenNoVacationTookPlaceByYear(list, 2021);
  foreach (var item in listOfDatesOfWhenNoVacationsTookPlaceIn2021)
  {
   Console.WriteLine($"{item.Year} - {item.Month} - {item.Day}");
  }
  
  Console.WriteLine("\nEmployees which had multiple vacations:");
  foreach (var item in VacationInformationTools.CheckData(list))
  {
   Console.WriteLine($"Name of employee: {item.Item1}\nEmployee's holidays intersect: {item.Item2}\n");
  }
 }
}