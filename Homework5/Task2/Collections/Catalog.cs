using System.Collections;
using System.Text;
using Task2.Classes;

namespace Task2.Collections
{
 class Catalog : IEnumerable<(string, Book)>
 {
  private List<(string, Book)> _books = new List<(string, Book)> ();

  private string ReturnNormalizedISBNFormat(string ISBN)
  {
   if (ISBN.Length == 17)
   {
    StringBuilder stringBuilder = new StringBuilder();
    for (int i = 0; i < 17; i++)
    {
     if (i != 3 && i != 5 && i != 8 && i != 15)
     {
      stringBuilder.Append(ISBN[i]);
     }
    }
    return stringBuilder.ToString();
   }
   return ISBN;
  }

  private bool IsDuplicate((string ISBN, Book book) bookTuple)
  {
   var normalizedISBN = ReturnNormalizedISBNFormat(bookTuple.ISBN);
   foreach (var book in _books)
   {
    if (book.Item1 == normalizedISBN && book.Item2.Title == bookTuple.book.Title) // for simplisity I check only for titles instead of implementing Equals method
    {
     return true;
    }
   }
   return false;
  }

  private bool IsKeyExists(string ISBN)
  {
   var normalizedISBN = ReturnNormalizedISBNFormat(ISBN);
   foreach (var book in _books)
   {
    if (book.Item1 == normalizedISBN)
    {
     return true;
    }
   }
   return false;
  }

  private Book GetBookByISBN(string ISBN)
  {
   var normalizedISBN = ReturnNormalizedISBNFormat(ISBN);
   foreach (var book in _books)
   {
    if (book.Item1 == normalizedISBN)
    {
     return book.Item2 as Book;
    }
   }
   throw new ArgumentException();
  }
  
  public void Add(string ISBN, Book book)
  {
   if (IsDuplicate((ISBN, book)))
   {
    throw new ArgumentException();
   }
   var normalizedISBN = ReturnNormalizedISBNFormat(ISBN);
   _books.Add((normalizedISBN, book));
  }

  public Book this[string ISBN]
  {
   get => IsKeyExists(ISBN) ? GetBookByISBN(ISBN) : throw new KeyNotFoundException();
  }

  public IEnumerator<(string, Book)> GetEnumerator()
  {
   return _books.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
   return GetEnumerator();
  }
 }
}
