using System.Collections;
using Task2.Classes;

namespace Task2.Collections
{
 class Catalog : IEnumerable<(string, Book)>
 {
  private List<(string, Book)> _books = new List<(string, Book)> ();

  // doesnt check for a different ISBN format yet
  private bool IsDuplicate((string ISBN, Book book) bookTuple)
  {
   foreach (var book in _books)
   {
    if (book.Item1 == bookTuple.ISBN && book.Item2.Title == bookTuple.book.Title) // for simplisity I check only for titles instead of implementing Equals method
    {
     return true;
    }
   }
   return false;
  }

  // doesnt check for a different ISBN format yet
  private bool IsKeyExists(string ISBN)
  {
   foreach (var book in _books)
   {
    if (book.Item1 == ISBN)
    {
     return true;
    }
   }
   return false;
  }

  // doesnt check for a different ISBN format yet
  private Book GetBookByISBN(string ISBN)
  {
   foreach (var book in _books)
   {
    if (book.Item1 == ISBN)
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
   _books.Add((ISBN, book));
  }

  public Book this[string ISBN]
  {
   get
   {
    if (!IsKeyExists(ISBN))
    {
     throw new KeyNotFoundException();
    }
    return GetBookByISBN(ISBN);
   }
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
