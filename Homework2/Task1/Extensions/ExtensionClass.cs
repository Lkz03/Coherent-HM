using Task1.Classes;
static class ExtensionClass
{
 public delegate T Addition<T>(T firstElement, T secondElement);
 public static GenericDiagonalMatrix<T> AddMatrixes<T>(this GenericDiagonalMatrix<T> matrixOne, GenericDiagonalMatrix<T> matrixTwo, Addition<T> addition)
 {
  T[] elementsOfNewMatrix;

  void SetNewMatrixSize(GenericDiagonalMatrix<T> parMatrix)
  {
   elementsOfNewMatrix = new T[parMatrix.Size];
  }

  void AddElementsWithPadding(GenericDiagonalMatrix<T> defaultMatrix, GenericDiagonalMatrix<T> biggerMatrix)
  {
   for (int i = 0; i < defaultMatrix.Size; i++)
   {
    elementsOfNewMatrix[i] = addition(defaultMatrix[i, i], biggerMatrix[i, i]);
   }
   for (int i = defaultMatrix.Size; i < biggerMatrix.Size; i++)
   {
    elementsOfNewMatrix[i] = default(T);
   }
  }

  if (matrixOne.Size >= matrixTwo.Size)
  {
   SetNewMatrixSize(matrixOne);

   AddElementsWithPadding(matrixTwo, matrixOne);
  }
  else
  {
   SetNewMatrixSize(matrixTwo);

   AddElementsWithPadding(matrixOne, matrixTwo);
  }

  GenericDiagonalMatrix<T> newMatrix = new GenericDiagonalMatrix<T>(elementsOfNewMatrix);
  return newMatrix;
 }
}
