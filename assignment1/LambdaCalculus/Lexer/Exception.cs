using System.Data;

namespace LambdaCalculus.Lexer;

public class UnexpectedCharacterException : Exception
{
	public UnexpectedCharacterException(char character, int position)
		: base($"Unexpected character '{character}' at position {position}.")
	{
	}
}

public class MissingParenthesesException : Exception
{
	public MissingParenthesesException(int position)
		: base($"Missing parentheses at position {position}.")
	{
	}
}
