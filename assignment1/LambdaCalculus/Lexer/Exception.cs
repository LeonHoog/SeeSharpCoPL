namespace LambdaCalculus.Lexer;

public class UnexpectedCharacterException : Exception
{
	public UnexpectedCharacterException(char character, int position)
		: base($"Unexpected character '{character}' at position {position}.")
	{
	}
}