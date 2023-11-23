namespace LambdaCalculus.Lambda;

/// <summary>
/// Represents a lambda abstraction
/// </summary>
public class LambdaAbstraction : ILambdaExpression
{
	/// <summary>
	/// The name of the variable
	/// </summary>
	public LambdaVariable Name { get; set; }

	/// <summary>
	/// The body of the abstraction
	/// </summary>
	public ILambdaExpression Body { get; set; }

	/// <summary>
	/// Creates a new lambda abstraction
	/// </summary>
	/// <param name="name">The name of the variable</param>
	/// <param name="body">The body of the abstraction</param>
	public LambdaAbstraction(LambdaVariable name, ILambdaExpression body)
	{
		Name = name;
		Body = body;
	}
}
