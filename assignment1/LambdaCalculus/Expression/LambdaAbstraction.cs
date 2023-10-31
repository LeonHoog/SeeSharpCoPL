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

	public LambdaAbstraction(LambdaVariable name, ILambdaExpression body)
	{
		Name = name;
		Body = body;
	}
}
