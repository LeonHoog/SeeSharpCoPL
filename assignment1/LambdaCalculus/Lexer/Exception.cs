namespace LambdaCalculus.Lexer;

/// <summary>
/// Thrown when the lexer encounters an unexpected character
/// </summary>
public class UnexpectedCharacterException : Exception
{
	public UnexpectedCharacterException(char character, int position)
		: base($"Unexpected character '{character}' at position {position}.")
	{
	}
}

/// <summary>
/// Thrown when the lexer encounters a missing parentheses
/// </summary>
public class MissingParenthesesException : Exception
{
	public MissingParenthesesException(int position)
		: base($"Missing parentheses at position {position}.")
	{
	}
}
