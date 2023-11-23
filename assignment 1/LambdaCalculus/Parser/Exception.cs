namespace LambdaCalculus.Parser;

/// <summary>
/// Thrown when the parser encounters an unexpected token
/// </summary>
public class UnexpectedTokenException : Exception
{
	/// <summary>
	/// Creates a new unexpected token exception
	/// </summary>
	/// <param name="message">The message of the exception</param>
	public UnexpectedTokenException(string message) : base($"Unexpected token '{message}'") { }
}

/// <summary>
/// Thrown when the parser encounters an unexpected end of input
/// </summary>
public class UnexpectedEndOfInputException : Exception
{
	/// <summary>
	/// Creates a new unexpected end of input exception
	/// </summary>
	/// <param name="message">The message of the exception</param>
	public UnexpectedEndOfInputException(string message = "Unexpected end of input") : base(message) { }
}

/// <summary>
/// Thrown when the parser encounters an unpairded parentheses
/// </summary>
public class UnpairedParenthesesException : Exception
{
	/// <summary>
	/// Creates a new unpaired parentheses exception
	/// </summary>
	/// <param name="message">The message of the exception</param>
	public UnpairedParenthesesException(string message = "Unpaired parentheses") : base(message) { }
}

/// <summary>
/// Thrown when the parser encounters an empty parentheses pair
/// </summary>
public class EmptyParenthesesException : Exception
{
	public EmptyParenthesesException(string message = "Empty parentheses") : base(message) { }
}
