namespace Task1.Classes
{
 public class MatrixElementChangedEventArgs<T> : EventArgs
 {
  public T OldElement { get; }
  public T NewElement { get; }
  public int IndexOfOldElement { get; }

  public MatrixElementChangedEventArgs(T oldElement, T newElement, int index)
  {
   OldElement = oldElement;
   NewElement = newElement;
   IndexOfOldElement = index;
  }
 }
}
