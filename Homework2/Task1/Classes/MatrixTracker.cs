namespace Task1.Classes
{
 class MatrixTracker<T>
 {
  private GenericDiagonalMatrix<T> _storedEventMatrix;
  private MatrixElementChangedEventArgs<T> _storedElementChangedEventArgs;

  public MatrixTracker(GenericDiagonalMatrix<T> matrix) => matrix.OnElementChanged += DisplayEventMessage;

  public void Undo() => _storedEventMatrix[_storedElementChangedEventArgs.IndexOfOldElement, _storedElementChangedEventArgs.IndexOfOldElement] = _storedElementChangedEventArgs.OldElement;

  public void DisplayEventMessage(object sender, EventArgs args)
  {
   _storedEventMatrix = sender as GenericDiagonalMatrix<T>;
   _storedElementChangedEventArgs = args as MatrixElementChangedEventArgs<T>;
   Console.WriteLine($"old element: {_storedElementChangedEventArgs.OldElement}\nnew element: {_storedElementChangedEventArgs.NewElement}");
  }
 }
}
