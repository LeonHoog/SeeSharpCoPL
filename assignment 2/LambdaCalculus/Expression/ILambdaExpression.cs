namespace LambdaCalculus.Lambda;

/// <summary>
/// Represents a lambda expression
/// </summary>
public interface ILambdaExpression
{
	/// <summary>
	/// Reduces the expression
	/// </summary>
	/// <returns>The reduced expression</returns>
	internal ILambdaExpression Reduce();

	/// <summary>
	/// Substitutes all instances of the variable with the replacement
	/// </summary>
	/// <param name="variable">The variable to substitute</param>
	/// <param name="replacement">The replacement</param>
	/// <returns>The substituted expression</returns>
	ILambdaExpression Substitute(LambdaVariable variable, ILambdaExpression replacement);
}
