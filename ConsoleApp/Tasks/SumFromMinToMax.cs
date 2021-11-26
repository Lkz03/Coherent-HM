/*Task 3. The application asks the user for the number of elements in a numeric array (at
least two), and then in a loop -the elements themselves (of int type). After entering the
elements, the application prints out the original array and outputs the sum of the array
elements located between the smallest element in the array (the leftmost element if there
are several) and the largest element (the rightmost element if there are several). Develop
a console application that implements the specified functionality.
Example: array [1, 3, 5, 1, 0, 3, 0, 1]. The sum of the required elements = 5 + 1 + 0 = 6.*/

public class SumFromMinToMax
{
 private static int[] _array;

 private static void ReadArrayMembers()
 {
  int temp;

  Console.WriteLine("Enter the size for an array");
  temp = Convert.ToInt32(Console.ReadLine());
  _array = new int[temp];

  for (int i = 0; i < _array.Length; i++)
  {
   Console.WriteLine("Enter a number to add to the array");
   _array[i] = Convert.ToInt32(Console.ReadLine());
  }
 }

 private static int FindMinIndex()
 {
  int min = _array[0];
  int index = 0;

  for (int i = 1; i < _array.Length; i++)
  {
   if (_array[i] < min) 
   {
    min = _array[i];
    index = i;
   } 
  }
  return index;   
 }

 private static int FindMaxIndex()
 {
  int max = _array[0];
  int index = 0;

  for (int i = 1; i < _array.Length; i++)
  {
   if (_array[i] >= max)
   {
    max = _array[i];
    index = i;
   }
  }
  return index;
 }

 private static int SumMembers(int minIndex, int maxIndex)
 {
  int sum = 0;

  for (int i = minIndex; i <= maxIndex; i++)
  {
   sum += _array[i];
  }
  return sum;
 }

 private static void ReturnArray()
 {
  Console.WriteLine("Array: ");
  for (int i = 0; i < _array.Length; i++)
  {
   if (i != _array.Length - 1)
   {
    Console.Write(_array[i] + ", ");
   }
   else
   {
    Console.Write(_array[i]);
   }
  }
 }

 public static void ExecuteTask()
 {
  ReadArrayMembers();
  ReturnArray();
  Console.WriteLine("\nSum of numbers from min to max: " + SumMembers(FindMinIndex(), FindMaxIndex()));
 }
}
