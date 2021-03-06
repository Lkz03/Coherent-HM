public class Stack<T> : IStack<T>
{
 private int _margin;
 private T[] _array;
 private int _top = 0;

 public Stack(int margin)
 {
  _margin = margin;
  _array = new T[margin];
 }

 public Stack(T[] array)
 {
  _array = array;
  _margin = array.Length;
 }

 public bool IsEmpty()
 {
  return _top == 0;
 }

 public T Pop()
 {
  if (this.IsEmpty())
  {
   throw new IndexOutOfRangeException();
  }
  var temp = _array[_top];
  _array[_top] = default(T);
  _top--;
  return temp;
 }

 public void Push(T parObject)
 {
  if (_array.Length == _margin - 1)
  {
   throw new IndexOutOfRangeException();
  }

  _top++;
  _array[_top] = parObject;
 }

 public int Size()
 {
  return this._array.Length;
 }
}
