namespace Task2.Classes
{
 class Book
 {
  private string _title;  
  public List<string> Authors { get; set; }
  public string Title 
  {
   get => _title;

   private set 
   {
    if (String.IsNullOrEmpty(value))
    {
     throw new ArgumentNullException(nameof(value));
    }
    _title = value;
   }
  }
  public DateOnly Date { get; set; }

  public Book(string title) => Title = title;
  public Book(string title, DateOnly date) : this(title) => Date = date;
  public Book(string title, DateOnly date, List<string> authors) : this(title, date) => Authors = authors;
 }
}
