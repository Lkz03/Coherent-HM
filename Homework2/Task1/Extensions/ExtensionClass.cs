using Task1.Classes;
static class ExtensionClass
{
 public delegate T Addition<T>(T firstElement, T secondElement);
 public static GenericDiagonalMatrix<T> AddMatrixes<T>(this GenericDiagonalMatrix<T> matrixOne, GenericDiagonalMatrix<T> matrixTwo, Addition<T> addition)
 {
  bool isSizeEqual = matrixOne.Size == matrixTwo.Size;
  T[] elementsOfNewMatrix;

  void SetNewMatrixSize(GenericDiagonalMatrix<T> parMatrix)
  {
   elementsOfNewMatrix = new T[parMatrix.Size];
  }

  void AddElementsWithPadding(GenericDiagonalMatrix<T> smallerMatrix, GenericDiagonalMatrix<T> biggerMatrix)
  {
   for (int i = 0; i < smallerMatrix.Size; i++)
   {
    elementsOfNewMatrix[i] = addition(smallerMatrix[i, i], biggerMatrix[i, i]);
   }
   for (int i = smallerMatrix.Size; i < biggerMatrix.Size; i++)
   {
    elementsOfNewMatrix[i] = default(T);
   }
  }

  if (isSizeEqual)
  {
   elementsOfNewMatrix = new T[matrixOne.Size];

   for (int i = 0; i < matrixOne.Size; i++)
   {
    elementsOfNewMatrix[i] = addition(matrixOne[i, i], matrixTwo[i, i]);
   }
  }
  else
  {
   if (matrixOne.Size > matrixTwo.Size)
   {
    SetNewMatrixSize(matrixOne);

    AddElementsWithPadding(matrixTwo, matrixOne);
   }
   else
   {
    SetNewMatrixSize(matrixTwo);

    AddElementsWithPadding(matrixOne, matrixTwo);
   }
  }

  GenericDiagonalMatrix<T> newMatrix = new GenericDiagonalMatrix<T>(elementsOfNewMatrix);
  return newMatrix;
 }
}
