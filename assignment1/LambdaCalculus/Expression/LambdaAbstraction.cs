namespace LambdaCalculus.Lambda;
public class LambdaAbstraction : ILambdaExpression
{
	public LambdaVariable Name { get; set; }
	public ILambdaExpression Body { get; set; }

	public LambdaAbstraction(LambdaVariable name, ILambdaExpression body)
	{
		Name = name;
		Body = body;
	}
}
