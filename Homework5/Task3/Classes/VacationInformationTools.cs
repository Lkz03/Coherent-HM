using System.Linq;
using Task3.Records;

namespace Task3.Classes
{
 public static class VacationInformationTools
 {
  public static double GetAverageVacationDuration(List<EmployeeVacationInformation> list)
  {
   return list.Average(x => (x.LastDayVacation.Date - x.FirstDayVacation.Date).Days);
  }

  public static IEnumerable<(string, double)> GetAverageEmployeeVacationDuration(List<EmployeeVacationInformation> list)
  {
   var uniqueName = list.Select(x => x.Name).Distinct();

   double GetEmplyeeAverageVacationDurationByName(string name, List<EmployeeVacationInformation> list)
   {
    return list.Where(x => x.Name == name).Average(x => (x.LastDayVacation.Date - x.FirstDayVacation.Date).Days);
   }

   foreach (var name in uniqueName)
   {
    yield return (name, GetEmplyeeAverageVacationDurationByName(name, list));
   }
  }

  public static IEnumerable<(int, int)> GetNumberOfEmplyeesOnVacationByMonth(List<EmployeeVacationInformation> list)
  {
   int[] months = new int[14];

   foreach (var emplyee in list)
   {
    for (int i = emplyee.FirstDayVacation.Month; i <= emplyee.LastDayVacation.Month; i++)
    {
     months[i]++;
    }
   }

   for (int i = 1; i <= 13; i++)
   {
    if (months[i] > 0)
    {
     yield return (i, months[i]);
    }
   }
  }

  public static List<DateTime> GetMonthsWhenNoVacationTookPlaceByYear(List<EmployeeVacationInformation> list, int year)
  {
   List<EmployeeVacationInformation> newList = list.Where(x => x.LastDayVacation.Year >= year && x.FirstDayVacation.Year <= year).ToList();
   
   List<DateTime> GetDistinctDates(DateTime from, DateTime to)
   {
    List<DateTime> temp = new List<DateTime>();
   var tempFromDate = from;
    while (tempFromDate <= to)
    {
     temp.Add(tempFromDate);
     tempFromDate = tempFromDate.AddDays(1);
    }

    return temp.Distinct().ToList();
   }

   List<DateTime> datesWhenNoVacationsTookPlace = GetDistinctDates(new DateTime(year, 1, 1), new DateTime(year, 12, 31));
   List<DateTime> datesWhenVacationsTookPlace = new List<DateTime>();

   foreach (var employee in newList)
   {
    foreach (var item in GetDistinctDates(employee.FirstDayVacation, employee.LastDayVacation))
    {
     datesWhenVacationsTookPlace.Add(item);
    }
   }

   foreach (var item in datesWhenVacationsTookPlace)
   {
    datesWhenNoVacationsTookPlace.Remove(item);
   }

   return datesWhenNoVacationsTookPlace;
  }

  public static IEnumerable<(string, bool)> CheckData(List<EmployeeVacationInformation> list)
  {
   var duplicates = list.GroupBy(x => x.Name).Where(x => x.Count() > 1).Select(x => x.Key);

   var query = from employee in list
               join duplicate in duplicates
               on employee.Name
               equals duplicate
               where employee.Name == duplicate
               select employee;

   (string, bool) temp = (default(string), default(bool));
 
   foreach (var employee in query.DistinctBy(x => x.Name))
   {
    temp.Item1 = employee.Name;
    foreach (var duplicate in query.Where(x => x.Name == employee.Name && x != employee))
    {
     if (employee.LastDayVacation >= duplicate.FirstDayVacation && employee.LastDayVacation <= duplicate.LastDayVacation)
     {
      temp.Item2 = true;
      break;
     }
     temp.Item2 = false;
    }
    yield return temp;
   }
  }
 }
}
