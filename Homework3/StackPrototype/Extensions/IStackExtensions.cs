public static class IStackExtensions
{
 // at the moment when this method is used the original stack becomes empty, is this okey ?
 public static Stack<T> Reverse<T>(this IStack<T> stack)
 {
  Stack<T> _tempStack = new Stack<T>(stack.Size());
  
  while (!stack.IsEmpty())
  {
   _tempStack.Push(stack.Peek());
   stack.Pop();
  }

  return _tempStack;
 }
}
