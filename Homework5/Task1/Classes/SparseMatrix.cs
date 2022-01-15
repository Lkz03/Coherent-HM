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

   set => _sparseMatrix[i, j] = value;
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

   for (int i = 0; i < RowSize; i++)
   {
    for (int j = 0; j < ColumnSize; j++)
    {
     stringBuilder.Append(this[i, j]);
     if (j == ColumnSize - 1)
     {
      stringBuilder.Append('\n');
     }
    }
   }

   return stringBuilder.ToString();
  }

  public IEnumerable<(int, int, int)> GetNonZeroValues()
  {
   for (int i = 0; i < ColumnSize; i++)
   {
    for (int j = 0; j < RowSize; j++)
    {
     if (this[j, i] != 0)
     {
      yield return (j, i, this[j, i]);
     }
    }
   }
  }

  public int GetCount(int number)
  {
   int count = 0;
  
   for (int i = 0; i < RowSize; i++)
   {
    for (int j = 0; j < ColumnSize; j++)
    {
     if (this[i, j] == number)
     {
      count++;
     }
    }
   }

   return count;
  }

  // generic
  public IEnumerator<int> GetEnumerator()
  {
   // I guess I could have used: "_sparseMatrix.GetEnumerator()", but I imagine the task was to learn to make one ourselves.
   return new SparseMatrixEnumerator(this);
  }

  // non generic
  IEnumerator IEnumerable.GetEnumerator()
  {
   return this.GetEnumerator();
  }
 }
}
