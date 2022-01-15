using System.Collections;
using System.Text;
using Task1.Enumerators;

namespace Task1.Classes
{
 class SparseMatrix : IEnumerable<int>
 {
  private int[,] _sparseMatrix;
  public int RowSize { get; init; }
  public int ColumnSize { get; init; }

  public int this[int i, int j]
  {
   get
   {
    if (i < 0 || j < 0 ||
        i >= RowSize || j >= ColumnSize)
    {
     throw new IndexOutOfRangeException();
    }
    return _sparseMatrix[i, j];
   }

   private set => _sparseMatrix[i, j] = value;
  }

  public SparseMatrix(int rowSize, int columnSize) 
  { 
   if (RowSize < 0 || ColumnSize < 0)
   {
    throw new ArgumentOutOfRangeException();
   }
   RowSize = rowSize;
   ColumnSize = columnSize;
   _sparseMatrix = new int[RowSize, ColumnSize];
  }

  public override string ToString()
  {
   StringBuilder stringBuilder = new StringBuilder();

   foreach (var element in _sparseMatrix)
   {
    stringBuilder.Append(element);
   }

   return stringBuilder.ToString();
  }

  // generic
  public IEnumerator<int> GetEnumerator()
  {
   return new SparseMatrixEnumerator(this);
  }

  // non generic
  IEnumerator IEnumerable.GetEnumerator()
  {
   return this.GetEnumerator();
  }
 }
}
