﻿using System.Data;
using System.Text;

using LambdaCalculus.Lambda;
using LambdaCalculus.Parser;
using LambdaCalculus.Reducer;

// Make sure the current input encoding can handle unicode
// Set the input and output encoding to Unicode
Console.InputEncoding = Console.OutputEncoding = Encoding.UTF8;

// If there's no arguments, run the while loop
if (args.Length == 0)
	NormalLoop();

// If there's arguments, open the file and run the program
else
	FileLoop(args[0]);

void FileLoop(string path)
{
	// Open the file
	using StreamReader file = new(path);

	// Read the file line by line
	while (!file.EndOfStream)
	{
		// Read the line
		string line = file.ReadLine()!;

		// Parse the line
		ParseTest(line);
	}
}

void NormalLoop()
{
	while (true)
	{
		// Ask the user to enter a lambda expression
		Console.Write("Please enter an untyped lambda function to reduce: ");

		// If the user enters an empty string or exit, exit the program
		string input = Console.ReadLine()!;
		if (input is "" or "exit")
			break;

		// Parse the input
		ParseTest(input);
	}
}

void ParseTest(string line)
{
	// Parse the line, catch any exceptions and print them in red
	ILambdaExpression? expression;
	try
	{
		expression = Parser.Parse(line);

		// If the expression is null, throw an exception
		if (expression is null)
			throw new NoNullAllowedException("Expression is null");
	}
	catch (Exception e)
	{
		// Store the current foreground color
		ConsoleColor color = Console.ForegroundColor;

		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine($"Caught exception: {e.Message}");

		// Restore the foreground color
		Console.ForegroundColor = color;
		return;
	}

	// Print the expression
	Parser.Print(expression!);

	// Reduce the expression
	ILambdaExpression reduced = Reducer.Reduce(expression!);

	// Print the reduced expression
	Parser.Print(reduced);
}
