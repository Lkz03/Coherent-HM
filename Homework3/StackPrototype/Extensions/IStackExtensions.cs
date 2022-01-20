public static class IStackExtensions
{
 // NOTE to myself: at the moment when this method is used the original stack becomes empty - in production should be clonning
 public static Stack<T> Reverse<T>(this IStack<T> stack)
 {
  Stack<T> _tempStack = new Stack<T>(stack.Size());
  
  while (!stack.IsEmpty())
  {
   _tempStack.Push(stack.Pop());
  }

  return _tempStack;
 }
}
