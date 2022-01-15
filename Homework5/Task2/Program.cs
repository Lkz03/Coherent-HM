using Task2.Collections;
using Task2.Classes;

public class Program
{
 public static void Main()
 {
  Book book1 = new Book("one");
  Book book2 = new Book("two");
  Book book3 = new Book("three");
  //Book book4 = new Book("one"); //duplicate

  Catalog catalog = new Catalog();

  catalog.Add("1234567891231", book1);
  catalog.Add("1234567891232", book2);
  catalog.Add("1234567891233", book3);
  //catalog.Add("1234567891231", book4); //ArgumentException, trying to add a duplicate

  foreach (var item in catalog)
  {
   Console.WriteLine(item.Item1 + " " + item.Item2.Title);
  }

  Console.WriteLine($"\nBook by ISBN number: 1234567891232 - {catalog["1234567891232"].Title}");
 }
}