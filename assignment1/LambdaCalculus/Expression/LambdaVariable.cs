namespace LambdaCalculus.Lambda;

/// <summary>
/// Represents a lambda variable
/// </summary>
public class LambdaVariable : ILambdaExpression
{
	/// <summary>
	/// The name of the variable
	/// </summary>
	public string Name { get; set; }

	public LambdaVariable(string name) => Name = name;
}
