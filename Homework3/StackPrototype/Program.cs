/*
 Task 2. A stack is a LIFO data type that implements the following operations:
• Push (e) - pushing an item onto the stack
• Pop () - remove and return the last inserted element
• IsEmpty () - checking the stack for emptiness

The simplest software implementation of a stack is based on the use of an array. We allocate
memory for the array with a margin (this is the maximum stack size). Additionally, we store the
index of the last inserted element.
Steps:
1. Create a universal interface IStack<T> that describes operations with a stack that stores
elements of value types.
2. Create a generic Stack<T> class that implements the IStack<T> interface. In the
Stack<T> class, use an array-based stack implementation.
3. Create a generic extension method Reverse<T> () for the IStack<T> interface. This
method returns a new stack in which the elements of the original parameter stack are in reverse
order.
4. Test the work of the created types and methods in the console application.

(*) If you already know something about exceptions and exceptions, throw exceptions when an
attempt is made to pop an element from an empty stack, or when an element is added when
the maximum stack capacity is reached. If you do not know about exceptions, do nothing when
trying to add to a full stack, return default (T) when trying to pop from an empty stack
 */

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