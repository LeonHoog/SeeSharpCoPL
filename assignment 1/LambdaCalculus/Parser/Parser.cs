using LambdaCalculus.Lambda;
using LambdaCalculus.Lexer;

namespace LambdaCalculus.Parser;

/// <summary>
/// A parser for lambda expressions
/// </summary>
public static class Parser
{
	/// <summary>
	/// Parses an array of tokens into a lambda expression
	/// </summary>
	/// <param name="tokens">The array of tokens to parse</param>
	/// <returns>A lambda expression</returns>
	/// <exception cref="UnexpectedTokenException"></exception>
	/// <exception cref="UnexpectedEndOfInputException"></exception>
	/// <exception cref="UnpairedParenthesesException"></exception>
	public static ILambdaExpression? Parse(Token[] tokens)
	{
		// Convert the tokens to a queue where they get consumed from the front
		Queue<Token> tokenQueue = new(tokens);

		ILambdaExpression? root = ParseApplication();

		return root;

		// Parse an application
		ILambdaExpression? ParseApplication()
		{
			ILambdaExpression? argument = ParseAbstraction();

			// If there's no more tokens or the next token is a close parentheses, return the argument by itself
			Token? next = SoftPeekToken();
			if (argument == null || !next.HasValue || next.Value.Type == TokenType.CloseParentheses)
				return argument;

			// Parse the right side of the application
			ILambdaExpression? function = ParseApplication();

			// Return the application
			return new LambdaApplication(function!, argument);
		}

		// Parse an abstraction
		ILambdaExpression? ParseAbstraction()
		{
			// If the next token is a lambda, parse the abstraction
			Token next = PeekToken();

			if (next.Type == TokenType.Lambda)
			{
				// Consume the lambda token
				NextToken();

				// Parse the variable
				Token variable = NextToken();
				Assert(variable, TokenType.Variable);

				// The next token may be a dot, if it is, consume it
				next = PeekToken();
				if (next.Type == TokenType.Dot)
					NextToken();

				// Parse the body
				ILambdaExpression? body = ParseApplication();

				// Return the abstraction
				return new LambdaAbstraction(new LambdaVariable(NonNull(variable.Value)), body!);
			}

			// Otherwise, parse the atomic expression
			return ParseAtomic();
		}

		// Parse an atomic expression
		ILambdaExpression? ParseAtomic()
		{
			// If the next token is a variable, parse the variable
			Token next = PeekToken();

			if (next.Type == TokenType.Variable)
			{
				// Consume the variable token
				Token variable = NextToken();

				// Return the variable
				return new LambdaVariable(NonNull(variable.Value));
			}

			if (next.Type == TokenType.OpenParentheses)
			{
				// Consume the open parentheses token
				NextToken();

				// Parse the expression inside the parentheses
				ILambdaExpression? expression = ParseApplication();

				// Consume the close parentheses token
				Assert(NextToken(), TokenType.CloseParentheses);

				// Return the expression inside the parentheses
				return expression;
			}

			// Otherwise, throw an exception
			throw new UnexpectedTokenException(next);
		}

		// Helper function to get the next token and throw an exception if there are no more tokens
		Token NextToken()
		{
			return tokenQueue.Count switch
			{
				0 => throw new UnexpectedEndOfInputException(),
				_ => tokenQueue.Dequeue()
			};
		}

		// Helper function to peek at the next token and throw an exception if there are no more tokens
		Token PeekToken()
		{
			return tokenQueue.Count switch
			{
				0 => throw new UnexpectedEndOfInputException(),
				_ => tokenQueue.Peek()
			};
		}

		// Helper function to peek at the next token and return null if there are no more tokens
		Token? SoftPeekToken()
		{
			return tokenQueue.Count switch
			{
				0 => null,
				_ => tokenQueue.Peek()
			};
		}

		// Helper function to convert a nullable string to a non-nullable string and throw an exception if the string is null
		string NonNull(string? str)
		{
			return str switch
			{
				null => throw new UnexpectedEndOfInputException(),
				_ => str
			};
		}

		void Assert(Token token, TokenType type)
		{
			if (token.Type != type)
			{
				// If the unexpected token is a close parentheses, throw an UnexpectedCloseParenthesesException
				if (token.Type == TokenType.CloseParentheses)
					throw new UnpairedParenthesesException();

				// Otherwise, throw an UnexpectedTokenException
				throw new UnexpectedTokenException(token);
			}
		}
	}

	/// <summary>
	/// Parses a string into a lambda expression
	/// </summary>
	/// <param name="input">The string to parse</param>
	/// <returns>A lambda expression</returns>
	/// <exception cref="UnexpectedTokenException"></exception>
	/// <exception cref="UnexpectedEndOfInputException"></exception>
	/// <exception cref="UnpairedParenthesesException"></exception>
	public static ILambdaExpression? Parse(string input) =>
		Parse(Lexer.Lexer.Tokenize(input));

	/// <summary>
	/// Prints a lambda expression to the console
	/// </summary>
	/// <param name="expression">The lambda expression to print</param>
	public static void Print(ILambdaExpression expression)
	{
		// Store the color
		ConsoleColor color = Console.ForegroundColor;

		// Print the expression recursively
		PrintRecursive(expression);

		// Restore the color
		Console.ForegroundColor = color;
		Console.WriteLine();

		static void PrintRecursive(ILambdaExpression expression)
		{
			// Print the expression with brackets around each abstraction, use colors for each type of expression
			switch (expression)
			{

				case LambdaVariable variable:
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write(variable.Name);
					break;
				case LambdaAbstraction abstraction:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write("(λ");
					Console.Write(abstraction.Name.Name);
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write(".");
					PrintRecursive(abstraction.Body);
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write(")");
					break;
				case LambdaApplication application:
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.Write("(");
					PrintRecursive(application.Argument);
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.Write(" ");
					PrintRecursive(application.Function);
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.Write(")");
					break;
			}
		}
	}
}
