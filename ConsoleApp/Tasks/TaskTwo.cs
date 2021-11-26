/*Task 2. The 10-digit ISBN is a numeric code that uniquely identifies a book. It has the
following form: d1d2d3d4d5d6d7d8d9d10.. Digit d10 is a control one. It is calculated
according to the condition that the expression

10d1 + 9d2 + 8d3+.. .+ 1d10

(the sum of the products of code elements by the weight of their positions) must be a
multiple of 11. Create a program that prompts the user for a 9 character-digit string (the
first nine digits of the ISBN), calculates the check digit, and prints the resulting ISBN. Do
not check the correctness of the user's input - assume that the user does not make
mistakes when entering.*/

class TaskTwo
{
    private const int _ISBNcount = 10; //Constant declared, but not used. 
    private static string? _nineDigits = string.Empty; // Shut up warning about possible null

    private static void ReadInput()
    {
        Console.WriteLine("Enter the 9 digits of ISBN number:");
        _nineDigits = Console.ReadLine();
    }

    private static int GetCheckDigit()
    {        
        int[] result = new int[9];
        char[] temp = _nineDigits!.ToCharArray(); //! means that we are sure that user
           //do not pass null, per requirements and
           // we instruct complier turn off warning. 

        //Ususall we may do on null instead of !, but this is out of the scope now

        for (int i = 0; i < 9; i++)
        {
            //The goal of the update was not to remove multiplier variable,
            // but express that it represents digital position. 
            result[i] = (temp[i] - '0') * ( i + 1 ); 
        }
        return result.Sum() % 11;
    }

    public static void ExecuteTask()
    {
        ReadInput();
        Console.Write("ISBN: ");
        if (GetCheckDigit() != 10)
            Console.WriteLine("{0}{1}", _nineDigits, GetCheckDigit());
        else
            Console.WriteLine("{0}{1}", _nineDigits, 'X');
    }
}

