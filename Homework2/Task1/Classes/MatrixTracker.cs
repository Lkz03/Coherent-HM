namespace Task1.Classes
{
 class MatrixTracker<T>
 {
  // is it okey to store event information like this?
  private T _storedEventElement;
  private GenericDiagonalMatrix<T> _storedEventMatrix;
  private int _storedIndexOfOldElement;

  public MatrixTracker(GenericDiagonalMatrix<T> matrix)
  {
   matrix.OnElementChange += DisplayEventMessage;
  }

  public void Undo()
  {
   _storedEventMatrix[_storedIndexOfOldElement, _storedIndexOfOldElement] = _storedEventElement;
  }

  public void DisplayEventMessage(object sender, T oldElement, T newElement, int indexOfOldElement)
  {
   Console.WriteLine($"old element: {oldElement}\nnew element: {newElement}");
   _storedEventElement = oldElement;
   _storedIndexOfOldElement = indexOfOldElement;
   _storedEventMatrix = sender as GenericDiagonalMatrix<T>;
  }
 }
}
