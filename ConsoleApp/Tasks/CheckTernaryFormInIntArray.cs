/*Task 1. Create a console application, whichasks the user for two integers a and b (assume
that the user enters integers without errors). The application then prints out all integers
in the range from a (inclusive) to b (inclusive) that have exactly two 2's in their ternary
number system (0, 1, 2) representation. Develop a console application that implements
the specified functionality.*/

public class CheckTernaryFormInIntArray
{
 static private string _string = string.Empty;

 private static int ReturnArrayBeginning()
 {
  Console.WriteLine("Enter a number for array's beginning");
  return Convert.ToInt32(Console.ReadLine());
 }

 private static int ReturnArrayEnd() 
 {
  Console.WriteLine("Enter a number for array's ending");
  return Convert.ToInt32(Console.ReadLine());
 }

 static private string ConvertToTernary(int N)
 {
  string ternaryNumber = string.Empty;

  if (N == 0)
  {
   ternaryNumber = "0";
   return ternaryNumber;
  }

  while(N >= 1) 
  {
   ternaryNumber += N % 3;
   N /= 3;
  }
  return ternaryNumber;
 }

 static private bool IsHasTwoTwos(string parString)
 {
  int twoCount = 0;

  for(int i=0; i<parString.Length; i++)
  {
   if (parString[i] == '2')
   {
    twoCount++;
   }
  }
  return twoCount == 2 ? true : false;
 }

 static public void ExecuteTask()
 {
  int from = ReturnArrayBeginning();
  int to = ReturnArrayEnd();
  Console.WriteLine("Number in an array from a to b that have two digits '2' in the ternary form:");
  for (int i=from; i<=to; i++)
  {
   _string = ConvertToTernary(i);
   if (IsHasTwoTwos(_string))
   {
    Console.WriteLine(i);
   }
  }
 }
}
