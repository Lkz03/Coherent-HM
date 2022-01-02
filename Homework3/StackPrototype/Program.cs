public class Program
{
 public static void Main()
 {
  Stack<int> stack = new Stack<int>(11);
  Stack<int> reversedStack;

  Console.WriteLine(stack.IsEmpty()); // true
  //stack.Pop(); //Exception out of bounds

  for (int i = 1; i <= 10; i++)
  {
   stack.Push(i);
  }

  //stack.Push(11); //Exception out of bounds

  Console.WriteLine(stack.IsEmpty()); // false

  Console.WriteLine("stack:");
  while (!stack.IsEmpty())
  {
   Console.WriteLine(stack.Peek());
   stack.Pop();
  }

  for (int i = 1; i <= 10; i++)
  {
   stack.Push(i);
  }
  reversedStack = stack.Reverse();

  Console.WriteLine("\nreversed stack:");
  while (!reversedStack.IsEmpty())
  {
   Console.WriteLine(reversedStack.Peek());
   reversedStack.Pop();
  }

 }
}