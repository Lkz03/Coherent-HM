class Program
{ 
 public static void Main()
 {
  int[] arrayOfElementsForMatrix = { 1, 2, 3, 4, 5};
  var DiagonalMatrix = new DiagonalMatrix(arrayOfElementsForMatrix);

  Console.WriteLine(DiagonalMatrix.Track());
 }
}