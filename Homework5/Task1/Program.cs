/*
 Task 1. Sparse numeric matrices are matrices in which only a relatively small fraction of the
elements are non-zero (https://en.wikipedia.org/wiki/Sparse_matrix). For example, if in a
100x100 matrix only the corner elements are non-zero (there are 4 of them), then we can
definitely call such a matrix sparse. Obviously, in order to save memory, it is desirable not to
store zero elements of a sparse matrix. You need to create and test a class to represent a sparse
matrix.
1. Create a SparseMatrix class to represent a sparse integer matrix (matrix elements are of
type int). A prerequisite is that the class must have a constructor that allows you to set the
dimensions of the matrix (the number of rows and the number of columns, strictly greater
than zero), and an indexer with two indices to access the matrix elements. You can use any
collection of your choice as internal storage. It is desirable to provide acceptable
performance and reasonable memory consumption.
2. For the convenience of debugging, redefine the ToString() method in the matrix class.
3. Implement the IEnumerable<int> interface in the SparseMatrix class. All elements of
the matrix, including zero ones, should be returned (a line-by-line traversal is done).
4. Describe the GetNozeroElements() method in the SparseMatrix class. The return type is
IEnumerable<(int, int, int)>. The method returns a set of tuples of the form (index_i,
index_j, value) for all non-null elements. Indexes must be ordered by columns, then by rows
- that is, non-null elements from the first column first, then non-null elements from the
second column, and so on.
5. Provide the SparseMatrixclass with the GetCount(x) method. It should return the number
of times element x occurs in the matrix. When implementing the GetCount(x) method, be
aware that x can be 0.
 */

using Task1.Classes;

public class Program
{
 public static void Main()
 {
  SparseMatrix sparseMatrix = new SparseMatrix(10, 10);

  Console.WriteLine("ToString:");
  Console.WriteLine(sparseMatrix.ToString());

  // the last element of the matrix is missing in foreach loop, not sure why
  Console.WriteLine("Foreach:");
  int index = 0; // is there a better way to display all elements as a matrix in foreach ?
  foreach (var element in sparseMatrix)
  {
   index++;
   Console.Write(element);
   if (index == 10)
   {
    Console.WriteLine();
    index = 0;
   }
  }
  Console.WriteLine("\n");

  sparseMatrix[0, 1] = 2;
  sparseMatrix[0, 2] = 2;
  sparseMatrix[2, 1] = 3;

  foreach ((int, int, int) element in sparseMatrix.GetNonZeroValues().OrderBy(x => x.Item2).ThenBy(x => x.Item1))
  {
   Console.WriteLine(element.Item3);
  }

  Console.WriteLine($"\ncount of '2' is {sparseMatrix.GetCount(2)}");
 }
}