/*Task 1. Create a console application, whichasks the user for two integers a and b (assume
that the user enters integers without errors). The application then prints out all integers
in the range from a (inclusive) to b (inclusive) that have exactly two 2's in their ternary
number system (0, 1, 2) representation. Develop a console application that implements
the specified functionality.*/

class TaskOne
{
 static private int _from, _to;
 static private string _string = String.Empty;

 static private void readInput()
 {
  Console.WriteLine("Enter number a");
  _from = Convert.ToInt32(Console.ReadLine());
  Console.WriteLine("Enter number b");
  _to = Convert.ToInt32(Console.ReadLine());
 }

 static private string convertToTernary(int N)
 {
  string ternaryNumber = String.Empty;

  if (N == 0)
  return ternaryNumber = "0";

  while(N >= 1) 
  {
   ternaryNumber += N % 3;
   N /= 3;
  }
  return ternaryNumber;
 }

 static private bool hasTwos(string parString)
 {
  for(int i=0; i<parString.Length; i++)
  {
   if (parString[i] == '2') return true;
  }
  return false;
 }

 static public void executeTask()
 {
  readInput();
  Console.WriteLine("Number in an array from a to b that have a digit '2' in the ternary form:");
  for (int i=_from; i<=_to; i++)
  {
   _string = convertToTernary(i);
   if(hasTwos(_string)) Console.WriteLine(i);
  }
 }
}
