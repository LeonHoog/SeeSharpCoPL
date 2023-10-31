namespace LambdaCalculus.Lambda;
public class LambdaVariable : ILambdaExpression
{
	public string Name { get; set; }

	public LambdaVariable(string name) => Name = name;
}
