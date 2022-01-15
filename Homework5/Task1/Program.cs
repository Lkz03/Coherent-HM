using Task1.Classes;

public class Program
{
 public static void Main()
 {
  SparseMatrix sparseMatrix = new SparseMatrix(10, 10);

  Console.WriteLine("ToString:");
  Console.WriteLine(sparseMatrix.ToString());

  // the last element of the matrix is missing in foreach loop, not sure why
  Console.WriteLine("Foreach:");
  int index = 0; // is there a better way to display all elements as a matrix in foreach ?
  foreach (var element in sparseMatrix)
  {
   index++;
   Console.Write(element);
   if (index == 10)
   {
    Console.WriteLine();
    index = 0;
   }
  }
  Console.WriteLine("\n");

  sparseMatrix[0, 1] = 2;
  sparseMatrix[0, 2] = 2;
  sparseMatrix[2, 1] = 3;
  foreach ((int, int, int) element in sparseMatrix.GetNonZeroValues())
  {
   Console.WriteLine(element);
  }

  Console.WriteLine($"\ncount of '2' is {sparseMatrix.GetCount(2)}");
 }
}