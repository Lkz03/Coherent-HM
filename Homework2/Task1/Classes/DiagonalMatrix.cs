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
using System.Text;

class DiagonalMatrix
{
 private int[] _matrixArray;
 public int this[int i, int j]
 {
  get
  {
   if (i < 0 ||
       i >= Size)
   {
    throw new Exception();
   }
   if (i != j)
   {
    return 0;
   }
   return _matrixArray[i];
  }

  private set => _matrixArray[i] = value;
 }

 public int Size { get; }

 public DiagonalMatrix(params int[] diagonalMatrixElements) 
 {
  if (diagonalMatrixElements == null)
  {
   Size = 0;
  }
  else
  {
   _matrixArray = new int[diagonalMatrixElements.Length];
   for (int i = 0; i < diagonalMatrixElements.Length; i++)
   { 
    this[i, i] = diagonalMatrixElements[i];
   }
   Size = diagonalMatrixElements.Length;
  }
 }

 public int Track()
 {
  return _matrixArray.Sum();
 }

 public override string ToString()
 {
  StringBuilder stringBuilder = new StringBuilder();

  for (int i = 0; i < Size; i++)
  {
   stringBuilder.Append(this[i, i] + " ");
  }

  return stringBuilder.ToString();
 }

 public bool Equals(int[] parArray)
 {
  if (Size == parArray.Length)
  {
   for (int i = 0; i < Size; i++)
   {
    if (parArray[i] != this[i, i])
    {
     return false;
    }
   }
   return true;
  }
  return false;
 }
}
