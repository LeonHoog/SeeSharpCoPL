namespace LambdaCalculus.Lexer;

/// <summary>
/// Represents a token
/// </summary>
public readonly struct Token
{
	/// <summary>
	/// The type of the token
	/// </summary>
	public TokenType Type { get; }

	/// <summary>
	/// The value of the token
	/// </summary>
	public string? Value { get; }

	/// <summary>
	/// Creates a new token
	/// </summary>
	/// <param name="type">The type of the token</param>
	/// <param name="value">The value of the token</param>
	public Token(TokenType type, string? value)
	{
		Type = type;
		Value = value;
	}

	/// <summary>
	/// Creates a new token with no value
	/// </summary>
	/// <param name="type">The type of the token</param>
	public Token(TokenType type) : this(type, null) { }

	/// <summary>
	/// Returns a string representation of the token
	/// </summary>
	/// <returns>A string representation of the token</returns>
	public override string ToString() =>
		$"{Type} ({Value})";

	// Allow implicit conversion from Token to TokenType
	public static implicit operator TokenType(Token token) =>
		token.Type;

	// Allow implicit conversion from Token to string
	public static implicit operator string(Token token) =>
		token.Value ?? throw new FormatException("Token value is null");
}

/// <summary>
/// Represents the type of a token
/// </summary>
public enum TokenType
{
	Variable,
	Lambda,
	Dot,
	OpenParentheses,
	CloseParentheses,
}
