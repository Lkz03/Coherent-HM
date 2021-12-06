/* 
You need to create and test a class to represent a diagonal matrix containing integers (int).

1. The class object stores only the elements of the matrix located on the diagonal. For this,
a one-dimensional array is used.

2. The class object has a read-only property Size - the size of the matrix (for example, for a
5x5 matrix, the Size property returns 5).

3. The class has a constructor for creating a matrix. A list of parameters (params) is passed
to the constructor - these are the elements of the matrix located on the diagonal. If the
value of the constructor argument is not correct (for example, equal to null), a zero-size
matrix is created (Size = 0).

4. For convenience, the class offers an indexer with two indices i and j. If i is not equal to j,
then the indexer returns the value 0 (when writing, nothing happens). If the values of the
indices are not correct (out of bounds: less than zero or greater or equal to Size), nothing
happens during writing, and when reading, the value 0 is returned. (In this case an exception has
to be generated, but up to now this point wasn’t discussed).

5. The class of the matrix has an instance method Track (), which returns the sum of the
elements of the matrix located on the main diagonal.

6. Override the Equals () and ToString () methods in the matrix class. Two matrices are
considered equal if their sizes and the corresponding elements on the diagonal coincide.

7. Create a diagonal matrix extension method that adds two diagonal matrices. The result
of the method is a new diagonal matrix. If the dimensions of the matrix do not match, the
smaller matrix is padded with zeros
*/

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
