namespace LambdaCalculus.Parser;

/// <summary>
/// Thrown when the parser encounters an unexpected token
/// </summary>
public class UnexpectedTokenException : System.Exception
{
	public UnexpectedTokenException(string message = "Unexpected token") : base(message) { }
}

/// <summary>
/// Thrown when the parser encounters an unexpected end of input
/// </summary>
public class UnexpectedEndOfInputException : System.Exception
{
	public UnexpectedEndOfInputException(string message = "Unexpected end of input") : base(message) { }
}

/// <summary>
/// Thrown when the parser encounters an unpairded parentheses
/// </summary>
public class UnpairedParenthesesException : System.Exception
{
	public UnpairedParenthesesException(string message = "Unpaired parentheses") : base(message) { }
}

/// <summary>
/// Thrown when the parser encounters an empty parentheses pair
/// </summary>
public class EmptyParenthesesException : System.Exception
{
	public EmptyParenthesesException(string message = "Empty parentheses") : base(message) { }
}