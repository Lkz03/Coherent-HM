/* 
Task 1. This task is based on the diagonal matrix task. According to the classical definition, a
numerical diagonal matrix is a square matrix in which all elements outside the main diagonal
are equal to zero. In the same task, you need to create a generic classfor a diagonal matrix with
elements of any type T (elements outside the main diagonal are equal to the default value for T

1. The class object stores only the elements of the matrix located on the diagonal. For this, a
one-dimensional array is used.
2. The class has a constructor for creating a matrix. The size of the matrix is passed to the
constructor (for example, 5 for a 5x5 matrix). If the argument is negative, an exception is
thrown ArgumentException.
3. The class object has a read-only property Size - the size of the matrix (for example, for a 5x5
matrix, the Size property returns 5).
4. For convenience, the class offers an indexer with two indices i and j. If the index values are
less than zero or greater than or equal to the size of the matrix, an
IndexOutOfRangeException is thrown. If i is not equal to j: when reading, the default
value for type T is returned, and when writing, nothing happens.
5. The matrix class contains an ElementChanged event that occurs after a matrix element has
changed, and only if the new value of the element is different from the old value. As
additional information, the indexes of the element, the old value of the element, and the
new value of the element are passed to the event as additional information. Attention: use
standard practices for working with events!
6. Create a diagonal matrix extension method that adds the two diagonal matrices. One of the
method's parameters must be a delegate instance describing how to perform the addition
of two elements of type T (this is a function with two parameters). Test the extension
method
7. Implement a MatrixTracker class that receives a diagonal matrix as a constructor
parameter, subscribes to its ElementChangedevent, and has a public Undo() method. When
this method is called, the last element change made in the matrix is rolled back (i.e.
cancelled).
*/
using Task1.Classes;

class Program
{
 public static void Main()
 {
  // Am I supposed to create a generic method to pass(like now) or with an already known type ?
  // I understand this is not a safe method but I am not sure how to make it safe while keeping it generic.
  T Addition<T>(T firstElement, T secondElement)
  {
   dynamic first = (dynamic)firstElement;
   dynamic second = (dynamic)secondElement;
   return first + second;
  }
 
  int[] arrayOfElementsForMatrixOne = { 1, 2, 3, 4, 5};
  int[] arrayOfElementsForMatrixTwo = { 5, 5, 5, 5, 5, 5 };
  var DiagonalMatrixOne = new GenericDiagonalMatrix<int>(arrayOfElementsForMatrixOne);
  var DiagonalMatrixTwo = new GenericDiagonalMatrix<int>(arrayOfElementsForMatrixTwo);

  MatrixTracker<int> matrixTracker = new MatrixTracker<int>(DiagonalMatrixOne);

  DiagonalMatrixOne[4, 4] = 6;
  matrixTracker.Undo();

  DiagonalMatrixOne = DiagonalMatrixOne.AddMatrixes(DiagonalMatrixTwo, Addition);
  for (int i = 0; i<DiagonalMatrixOne.Size; i++)
  {
   Console.WriteLine(DiagonalMatrixOne[i, i]);
  }
 }
}