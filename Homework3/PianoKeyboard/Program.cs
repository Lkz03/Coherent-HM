class Program
{
 public static void Main()
 {
  Key c = new Key('c', "Sharp", "First");
  Key d = new Key('d', "Flat", "First");

  Console.WriteLine(c.Equals(d));
  Console.WriteLine(c.Compare(d));
  Console.WriteLine(c.ToString());
  Console.WriteLine(d.ToString());
 }
}
