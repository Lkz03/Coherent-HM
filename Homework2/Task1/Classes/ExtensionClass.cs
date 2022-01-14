static class ExtensionClass
{
 public static DiagonalMatrix AddMatrixes(this DiagonalMatrix matrixOne, DiagonalMatrix matrixTwo)
 {
  bool isSizeEqual = matrixOne.Size == matrixTwo.Size;
  int[] elementsOfNewMatrix;

  void SetNewMatrixSize(DiagonalMatrix parMatrix)
  {
   elementsOfNewMatrix = new int[parMatrix.Size];
  }

  void AddElementsWithPadding(DiagonalMatrix parSmallerMatrix, DiagonalMatrix parBiggerMatrix)
  {
   for (int i = 0; i < parSmallerMatrix.Size; i++)
   {
    elementsOfNewMatrix[i] = parSmallerMatrix[i, i] + parBiggerMatrix[i, i];
   }
   for (int i = parSmallerMatrix.Size; i < parBiggerMatrix.Size; i++)
   {
    elementsOfNewMatrix[i] = 0;
   }
  }

  if (isSizeEqual)
  {
   elementsOfNewMatrix = new int[matrixOne.Size];

   for (int i = 0; i < matrixOne.Size; i++)
   {
    elementsOfNewMatrix[i] = matrixOne[i, i] + matrixTwo[i, i];
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

  DiagonalMatrix newMatrix = new DiagonalMatrix(elementsOfNewMatrix);
  return newMatrix;
 }
}
