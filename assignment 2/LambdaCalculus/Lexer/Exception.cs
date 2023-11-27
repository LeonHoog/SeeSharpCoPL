namespace LambdaCalculus.Lexer;

/// <summary>
/// Thrown when the lexer encounters an unexpected character
/// </summary>
public class UnexpectedCharacterException : Exception
{
	/// <summary>
	/// Creates a new unexpected character exception
	/// </summary>
	/// <param name="character">The unexpected character</param>
	/// <param name="position">The position of the unexpected character</param>
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
	/// <summary>
	/// Creates a new missing parentheses exception
	/// </summary>
	/// <param name="position">The position of the missing parentheses</param>
	public MissingParenthesesException(int position)
		: base($"Missing parentheses at position {position}.")
	{
	}
}
