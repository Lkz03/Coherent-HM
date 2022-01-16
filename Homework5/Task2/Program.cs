/*
 Task 2.
1. Create a simple class to represent the book. Store in the book class the title of the book (a
string, not empty, not null), the publication date (possibly null), and a set of book authors
(a collection of non-repeating strings, possibly empty).
2. The 13-digit ISBN of a book is a string in the format XXX-X-XX-XXXXXX-X or
XXXXXXXXXXXXX, where X is the number 0..9. Create your class: Catalog is a dictionary-like
collection that stores books. Provide access to the book by key-string - by the ISBN of the
book. Keep in mind an important nuance - if the book was placed in the catalog using the key
123-4-56-789012-3, then it can be extracted using both the key 123-4-56-789012-3 and the
key 1234567890123. Correctness of the ISBN itself in this task you can not check (no need to
check the check digits, it is desirable to check the correctness of the format itself - for
example, using regular expressions).
 */

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