class DiagonalMatrix
{

 private int _indexI;
 private int _indexJ;
 private int[] _matrixArray;// should this be called -> "MatrixArray" ? Or the way it is now is okey ?
 private int this[int i]
 {
  get => _matrixArray[i];
  set => _matrixArray[i] = value;
 }
 // Is this what was meant by the task1.4 ?
 private int MatrixBounds
 {
  get
  {
   if (_indexI != _indexJ ||
       _indexI < 0 ||
       _indexI >= Size)
   {
    return 0;
   }
   return _indexI;
  }
  set
  {
   _indexI = value;
   _indexJ = value;
  }
 }

 // Is it alright to call it "Size" instead of "_size" if it is readonly ?
 private readonly int Size;

 public DiagonalMatrix(params int[] diagonalMatrixElements) 
 {
  if (diagonalMatrixElements == null)
  {
   Size = 0;
  }
  else
  {
   for (int i = 0; i < diagonalMatrixElements.Length; i++)
   { 
    this[i] = diagonalMatrixElements[i];
   }
   Size = diagonalMatrixElements.Length;
  }
 }

 
}
