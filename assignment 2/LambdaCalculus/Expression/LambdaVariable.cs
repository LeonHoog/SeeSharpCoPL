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

	/// <summary>
	/// Reduces the expression
	/// </summary>
	/// <returns>The reduced expression</returns>
	public ILambdaExpression Reduce() => this;

	/// <summary>
	/// Substitutes all instances of the variable with the replacement
	/// </summary>
	/// <param name="variable">The variable to substitute</param>
	/// <param name="replacement">The replacement</param>
	/// <returns>The substituted expression</returns>
	public ILambdaExpression Substitute(LambdaVariable variable, ILambdaExpression replacement) =>
		// If the variable is the same as the current variable, return the replacement
		Equals(variable) ? replacement : this;
}
