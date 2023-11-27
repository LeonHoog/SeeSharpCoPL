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

	public ILambdaExpression Reduce()
	{
		// Beta reduction for lambda application
		if (Function is LambdaAbstraction abstraction)
			// Replace all instances of the bound variable with the argument
			return abstraction.Body.Substitute(abstraction.Name, Argument).Reduce();
		else
			// If the function is not an abstraction, reduce its parts
			return new LambdaApplication(Function.Reduce(), Argument.Reduce());
	}


	/// <summary>
	/// Substitutes all instances of the variable with the replacement
	/// </summary>
	/// <param name="variable">The variable to substitute</param>
	/// <param name="replacement">The replacement</param>
	/// <returns>The substituted expression</returns>
	public ILambdaExpression Substitute(LambdaVariable variable, ILambdaExpression replacement) =>
		// Perform substitution in both the function and the argument
		new LambdaApplication(Function.Substitute(variable, replacement), Argument.Substitute(variable, replacement));
}
