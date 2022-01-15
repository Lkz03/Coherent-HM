using System.Collections;
using Task1.Classes;

namespace Task1.Enumerators
{
 class SparseMatrixEnumerator : IEnumerator<int>
 {
  private SparseMatrix _sparseMatrix;
  private int _row;
  private int _col;

  public SparseMatrixEnumerator(SparseMatrix sparseMatrix)
  {
   _row = 0;
   _col = -1;
   _sparseMatrix = sparseMatrix;
  }

  public int Current => _sparseMatrix[_row, _col];

  object IEnumerator.Current => Current;

  public void Dispose()
  {
   // not needed for this collection
  }

  public bool MoveNext()
  {
   bool isRowOver = _col < _sparseMatrix.ColumnSize - 1 ? false : true;

   if (!isRowOver)
   {
    _col++;
   }
   if (isRowOver)
   {
    _row++; 
    _col = 0;
   }

   return _row >= _sparseMatrix.RowSize - 1 && _col >= _sparseMatrix.ColumnSize - 1 ? false : true;
  }

  public void Reset()
  {
   _row = -1;
   _col = -1;
  }
 }
}
