namespace LambdaCalculus.Lambda;

/// <summary>
/// Represents a lambda application
/// </summary>
public class LambdaApplication : ILambdaExpression
{
	/// <summary>
	/// The function of the application
	/// </summary>
	public ILambdaExpression Function { get; set; }

	/// <summary>
	/// The argument of the application
	/// </summary>
	public ILambdaExpression Argument { get; set; }

	/// <summary>
	/// Creates a new lambda application
	/// </summary>
	/// <param name="function">The function of the application</param>
	/// <param name="argument">The argument of the application</param>
	public LambdaApplication(ILambdaExpression function, ILambdaExpression argument)
	{
		Function = function;
		Argument = argument;
	}

	public IEnumerable<LambdaVariable> GetBoundVariables() => 
		Function.GetBoundVariables().Concat(Argument.GetBoundVariables());

	public IEnumerable<LambdaVariable> GetConflictVariables() =>
		Function.GetConflictVariables().Concat(Argument.GetConflictVariables());

	public void ResolveConflicts()
	{
		Function.ResolveConflicts();
		Argument.ResolveConflicts();
	}
}
