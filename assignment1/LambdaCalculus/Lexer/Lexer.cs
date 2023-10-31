using System.Text;

namespace LambdaCalculus.Lexer;

public static class Lexer
{
	/// <summary>
	/// Converts the input string into an array of tokens
	/// </summary>
	/// <param name="input">The input string to tokenize</param>
	/// <returns>An array of tokens</returns>
	public static Token[] Tokenize(string input)
	{
		// Create a list of tokens
		List<Token> tokens = new();

		// Create a variable to store the number of open parentheses
		int parentheses = 0;

		// Loop through each character in the input
		int index = 0;
		while (index < input.Length)
		{
			char c = input[index];

			// Check if the current character is a lambda, open parentheses, or close parentheses
			switch (c)
			{
				case '\\':
				case 'λ':
					tokens.Add(new(TokenType.Lambda, "λ"));
					index++;
					break;
				case '.':
					tokens.Add(new(TokenType.Dot, "."));
					index++;
					break;
				case '(':
					tokens.Add(new(TokenType.OpenParentheses, "("));
					index++;
					parentheses++;
					break;
				case ')':
					tokens.Add(new(TokenType.CloseParentheses, ")"));
					index++;
					parentheses--;

					// If the parentheses count is less than zero, throw an exception
					if (parentheses < 0)
						throw new UnexpectedCharacterException(')', index);

					break;
				default:
					// Check if the current character is a letter
					if (char.IsLetter(c))
					{
						// Create a string builder and loop through each character in the input until we reach a non-letter
						StringBuilder variable = new(5);

						// While the current character is not a lambda, open parentheses, close parentheses, or whitespace
						while (index < input.Length && input[index] is not '\\' and not 'λ' and not '.' and not '(' and not ')' && !char.IsWhiteSpace(input[index]))
							variable.Append(input[index++]);
						tokens.Add(new(TokenType.Variable, variable.ToString()));
					}
					// If we reach this point, the current character is not a lambda, open parentheses, close parentheses, or letter
					// So we throw an exception except if it's whitespace
					else if (!char.IsWhiteSpace(c))
					{
						throw new UnexpectedCharacterException(c, index);
					}
					else
					{
						index++;
					}

					break;
			}
		}

		// If the parentheses count is not zero, throw an exception
		if (parentheses != 0)
			throw new MissingParenthesesException(input.Length + 1);

		// Return the tokens
		return tokens.ToArray();
	}

	/// <summary>
	/// Prints the tokens to the console
	/// </summary>
	/// <param name="Tokens">The tokens to print</param>
	public static void Print(Token[] Tokens)
	{
		foreach (Token token in Tokens)
			Print(token);
	}

	/// <summary>
	/// Prints the token to the console
	/// </summary>
	/// <param name="token">The token to print</param>
	public static void Print(Token token)
	{
		// Store the current console color so we can reset it later
		ConsoleColor originalColor = Console.ForegroundColor;

		// Print each token in a different color
		Console.ForegroundColor = token.Type switch
		{
			TokenType.Variable => ConsoleColor.Green,
			TokenType.Lambda => ConsoleColor.Yellow,
			TokenType.Dot => ConsoleColor.Blue,
			TokenType.OpenParentheses => ConsoleColor.Red,
			TokenType.CloseParentheses => ConsoleColor.Red,
			_ => throw new NotImplementedException()
		};

		Console.Write(token.Value);

		// Reset the console color
		Console.ForegroundColor = originalColor;
	}
}
