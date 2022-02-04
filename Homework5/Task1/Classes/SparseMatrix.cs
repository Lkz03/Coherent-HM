using System.Collections;
using System.Text;
using Task1.Enumerators;

namespace Task1.Classes
{
 class SparseMatrix : IEnumerable<int>
 {
  // all non zero values in sparse matrix, first int - row index, second int - column index, third int - value
  private Dictionary<(int, int), int> _values = new Dictionary<(int, int), int>();
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
    return _values.GetValueOrDefault((i, j));
   }

   set
   {
    if (value != 0)
    {
     _values[(i, j)] = value;
    }
    else if (_values.GetValueOrDefault((i, j)) != 0)
    {
     _values.Remove((i, j));
    }
   }
  }

  public SparseMatrix(int rowSize, int columnSize) 
  { 
   if (RowSize < 0 || ColumnSize < 0)
   {
    throw new ArgumentOutOfRangeException();
   }
   RowSize = rowSize;
   ColumnSize = columnSize;
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

  // ordering is done in program.cs, is it okey ?
  // Ordering in the method would make the method very complicated instead of simple
  public IEnumerable<(int, int, int)> GetNonZeroValues()
  {
   foreach (var element in _values)
   {
    yield return (element.Key.Item1, element.Key.Item2, element.Value);
   }
  }

  public int GetCount(int number)
  {
   if (number == 0)
   {
    return RowSize * ColumnSize - _values.Count;
   }
   else
   {
    return _values.Count;
   }
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
