class Program
{ 
 public static void Main()
 {
  int[] arrayOfElementsForMatrixOne = { 1, 2, 3, 4, 5};
  int[] arrayOfElementsForMatrixTwo = { 5, 5, 5, 5, 5, 5 };
  var DiagonalMatrixOne = new DiagonalMatrix(arrayOfElementsForMatrixOne);
  var DiagonalMatrixTwo = new DiagonalMatrix(arrayOfElementsForMatrixTwo);

  DiagonalMatrixOne = DiagonalMatrixOne.AddMatrixes(DiagonalMatrixTwo);
  for (int i = 0; i < DiagonalMatrixOne.Size; i++)
  {
   Console.WriteLine(DiagonalMatrixOne[i, i]);
  }
 }
}