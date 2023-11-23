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

	/// <summary>
	/// Creates a new lambda variable
	/// </summary>
	/// <param name="name">The name of the variable</param>
	public LambdaVariable(string name) => Name = name;
}
