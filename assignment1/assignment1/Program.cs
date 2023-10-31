using System.Text;

using LambdaCalculus.Lambda;
using LambdaCalculus.Parser;

// Make sure the current input encoding can handle unicode
Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

while (true)
{
	// Ask the user to enter a lambda expression
	Console.Write("Please enter an untyped lambda function: ");

	// If the user enters an empty string or exit, exit the program
	string input = Console.ReadLine()!;
	if (input is "" or "exit")
		break;

	// Parse the input, catch any exceptions and print them in red
	ILambdaExpression? expression;
	try
	{
		expression = Parser.Parse(input);
	}
	catch (Exception e)
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine($"caught exception: {e.Message}");
		Console.ForegroundColor = ConsoleColor.White;
		continue;
	}

	// Print the expression
	Console.Write("Parsed expression: ");
	Parser.Print(expression!);
}