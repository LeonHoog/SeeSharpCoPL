namespace LambdaCalculus.Lambda;

/// <summary>
/// Represents a lambda expression
/// </summary>
public interface ILambdaExpression
{
	public void AlphaConverce()
	{

	}

	/// <summary>
	/// Gets the bound variables of the expression
	/// </summary>
	/// <returns>The bound variables of the expression</returns>
	internal IEnumerable<LambdaVariable> GetBoundVariables();

	/// <summary>
	/// Gets the conflicting variables of the expression
	/// </summary>
	/// <returns>The conflicting variables of the expression</returns>
	internal IEnumerable<LambdaVariable> GetConflictVariables();

	internal void ResolveConflicts();
}
