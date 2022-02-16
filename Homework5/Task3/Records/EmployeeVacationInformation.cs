namespace Task3.Records
{
 public record EmployeeVacationInformation
 {
  public string Name { get; init; }
  public DateTime FirstDayVacation { get; init; }
  public DateTime LastDayVacation { get; init;}

  public EmployeeVacationInformation(string name, DateTime firstDay, DateTime lastDay)
  {
   Name = name;
   FirstDayVacation = firstDay;
   LastDayVacation = lastDay;
  }
 }
}
