static class ExtensionClass
{
 public static DiagonalMatrix AddMatrixes(this DiagonalMatrix matrixOne, DiagonalMatrix matrixTwo)
 {
  bool isSizeEqual = matrixOne.Size == matrixTwo.Size ? true : false;
  int sizeOfNewMatrix;
  int[] elementsOfNewMatrix;


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
    sizeOfNewMatrix = matrixOne.Size;
    elementsOfNewMatrix = new int[sizeOfNewMatrix];

    for (int i = 0; i < matrixTwo.Size; i++)
    {
     elementsOfNewMatrix[i] = matrixOne[i, i] + matrixTwo[i, i];
    }
    for (int i = matrixTwo.Size; i < matrixOne.Size; i++)
    {
     elementsOfNewMatrix[i] = 0;
    }
   }
   else
   {
    sizeOfNewMatrix = matrixTwo.Size;
    elementsOfNewMatrix = new int[sizeOfNewMatrix];

    for (int i = 0; i < matrixOne.Size; i++)
    {
     elementsOfNewMatrix[i] = matrixOne[i, i] + matrixTwo[i, i];
    }
    for (int i = matrixOne.Size; i < matrixTwo.Size; i++)
    {
     elementsOfNewMatrix[i] = 0;
    }
   }
  }

  DiagonalMatrix newMatrix = new DiagonalMatrix(elementsOfNewMatrix);
  return newMatrix;
 }
}
