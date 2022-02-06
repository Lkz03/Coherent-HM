using System.Linq;
using Task3.Records;

namespace Task3.Classes
{
 public static class VacationInformationTools
 {
  public static double GetAverageVacationDuration(IEnumerable<EmployeeVacationInformation> list)
  {
   return list.Average(x => (x.LastDayVacation.Date - x.FirstDayVacation.Date).Days);
  }

  public static IEnumerable<(string, double)> GetAverageEmployeeVacationDuration(IEnumerable<EmployeeVacationInformation> list)
  {
   var uniqueName = list.Select(x => x.Name).Distinct();

   double GetEmployeeAverageVacationDurationByName(string name, IEnumerable<EmployeeVacationInformation> list)
   {
    return list.Where(x => x.Name == name).Average(x => (x.LastDayVacation.Date - x.FirstDayVacation.Date).Days);
   }

   foreach (var name in uniqueName)
   {
    yield return (name, GetEmployeeAverageVacationDurationByName(name, list));
   }
  }

  public static IEnumerable<(int, int)> GetNumberOfEmployeesOnVacationByMonth(IEnumerable<EmployeeVacationInformation> list)
  {
   int[] months = new int[14];

   foreach (var employee in list)
   {
    for (int i = employee.FirstDayVacation.Month; i <= employee.LastDayVacation.Month; i++)
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

  public static ICollection<DateTime> GetMonthsWhenNoVacationTookPlaceByYear(IEnumerable<EmployeeVacationInformation> list, int year)
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

  public static IEnumerable<(string, bool)> CheckData(IEnumerable<EmployeeVacationInformation> list)
  {
   IEnumerable<(string, bool)> Intersections(IGrouping<string, EmployeeVacationInformation> x)
   {
    var distinctNames = x.DistinctBy(x => x.Name);
    
    DateTime defaultStartDate;
    DateTime defaultEndDate;

    (string, bool) temp = new (default, false);

    foreach (var distinctEmployee in distinctNames)
    {
     temp.Item1 = distinctEmployee.Name;
     defaultStartDate = distinctEmployee.FirstDayVacation;
     defaultEndDate = distinctEmployee.LastDayVacation;
     foreach (var employee in list)
     {
      if (distinctEmployee == employee || distinctEmployee.Name != employee.Name)
      {
       continue;
      }
      if (employee.FirstDayVacation <= defaultEndDate && employee.LastDayVacation >= defaultStartDate)
      {
       temp.Item2 = true;
       if (employee.FirstDayVacation < defaultStartDate)
       {
        defaultStartDate = employee.FirstDayVacation;
       }
       if (employee.LastDayVacation > defaultEndDate)
       {
        defaultEndDate = employee.LastDayVacation;
       }
      }
     }
    }

    yield return temp;
   }

   var intersections = list.GroupBy(x => x.Name)
                           .Where(x => x.Count() > 1)
                           .SelectMany(x => Intersections(x));

   return intersections;
  }
 }
}
