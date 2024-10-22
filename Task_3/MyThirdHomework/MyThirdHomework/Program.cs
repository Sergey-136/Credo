//// See https://aka.ms/new-console-template for more information
////Console.WriteLine("Hello, World!");




////Task 3.1

////// Array of vowels (both lowercase and uppercase)
char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

Console.Write("Enter a string: ");

//////// Input the string
string input = Console.ReadLine();

//////// Variable to count the number of vowels
int vowelCount = 0;

//////// Iterate through each character in the input string
foreach (char c in input)
{
    // Check if the character is a vowel
    if (Array.Exists(vowels, element => element == c))
    {
        vowelCount++;
    }
}

//////// Output the result
Console.WriteLine("Number of vowels: " + vowelCount);

//////Task 3.2

////// Prompt the user for input
Console.Write("Enter a number: ");
int number = int.Parse(Console.ReadLine());

////// Create an array to store the multiplication table
int[] multiplicationTable = new int[10];

////// Generate the multiplication table and store it in the array
for (int i = 0; i < 10; i++)
{
    multiplicationTable[i] = number * (i + 1);
}

////// Print the multiplication table
Console.WriteLine($"Multiplication Table of {number}:");
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"{number} x {i + 1} = {multiplicationTable[i]}");

}

////Task 3.3

//// Declare two 3x3 matrices and one for the result
int[,] matrix1 = new int[3, 3];
int[,] matrix2 = new int[3, 3];
int[,] resultMatrix = new int[3, 3];

////// Fill the first matrix with user input
Console.WriteLine("Enter values for the first 3x3 matrix:");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($"Enter value for element [{i},{j}]: ");
        matrix1[i, j] = int.Parse(Console.ReadLine());
    }
}

////// Fill the second matrix with user input
Console.WriteLine("Enter values for the second 3x3 matrix:");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($"Enter value for element [{i},{j}]: ");
        matrix2[i, j] = int.Parse(Console.ReadLine());
    }
}

////// Add the two matrices
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
    }
}

////// Print the result matrix
Console.WriteLine("Result of matrix addition:");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(resultMatrix[i, j] + "\t");
    }
    Console.WriteLine();
}

////Task 3.4

bool keepRunning = true;

while (keepRunning)
{
    //    // Display the calculator menu
    Console.WriteLine("Calculator Menu:");
Console.WriteLine("1) Addition");
Console.WriteLine("2) Subtraction");
Console.WriteLine("3) Multiplication");
Console.WriteLine("4) Division");
Console.WriteLine("5) Exit");
Console.Write("Choose an option: ");

//    // Get user's choice
int choice = int.Parse(Console.ReadLine());

//    // Perform the selected operation or exit
if (choice == 5)
{
    keepRunning = false; // Exit the loop
    Console.WriteLine("Exiting...");
}
else
{
    //        // Get two numbers from the user
    Console.Write("Enter first number: ");
    double firstNumber = double.Parse(Console.ReadLine());

    Console.Write("Enter second number: ");
    double secondNumber = double.Parse(Console.ReadLine());

    //        // Perform the operation based on user choice
    if (choice == 1)
    {
        //            // Addition
        double result = firstNumber + secondNumber;
        Console.WriteLine($"Result: {result}");
    }
    else if (choice == 2)
    {
        //            // Subtraction
        double result = firstNumber - secondNumber;
        Console.WriteLine($"Result: {result}");
    }
    else if (choice == 3)
    {
        //            // Multiplication
        double result = firstNumber * secondNumber;
        Console.WriteLine($"Result: {result}");
    }
    else if (choice == 4)
    {
        //            // Division
        if (secondNumber != 0)
        {
            double result = firstNumber / secondNumber;
            Console.WriteLine($"Result: {result}");
        }
        else
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
    }
    else
    {
        Console.WriteLine("Invalid choice. Please choose a valid option.");
    }
}

//    // Repeat menu after each operation, unless exiting
Console.WriteLine();
}


//char[] vowels = {'a','e','i','o','u','y'};

//Console.WriteLine("Enter you text here")
//Console.ReadLine()





