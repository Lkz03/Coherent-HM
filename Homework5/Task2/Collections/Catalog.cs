using System.Collections;
using Task2.Classes;

namespace Task2.Collections
{
 class Catalog : IEnumerable<(string, Book)>
 {
  private List<(string, Book)> _books;

  public (string, Book) GetBookByISBN(string ISBN)
  {
   throw new NotImplementedException();
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
