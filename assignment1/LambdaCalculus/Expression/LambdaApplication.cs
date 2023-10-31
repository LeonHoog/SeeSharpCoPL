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

	public LambdaApplication(ILambdaExpression function, ILambdaExpression argument)
	{
		Function = function;
		Argument = argument;
	}
}
