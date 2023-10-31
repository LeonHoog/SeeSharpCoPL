namespace LambdaCalculus.Lambda;
public class LambdaApplication : ILambdaExpression
{
	public ILambdaExpression Function { get; set; }
	public ILambdaExpression Argument { get; set; }

	public LambdaApplication(ILambdaExpression function, ILambdaExpression argument)
	{
		Function = function;
		Argument = argument;
	}
}
