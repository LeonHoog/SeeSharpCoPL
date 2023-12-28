using LambdaCalculus.Lambda;

namespace LambdaCalculus.Reducer;
public class Reducer
{
	/// <summary>
	/// Reduces the expression
	/// </summary>
	/// <param name="expression">The expression to reduce</param>
	/// <returns>The reduced expression</returns>
	public static ILambdaExpression Reduce(ILambdaExpression expression) => 
		// Reduce the expression a maximum of 1000 times
		Reduce(expression, 1000);

	/// <summary>
	/// Reduces the expression
	/// </summary>
	/// <param name="expression">The expression to reduce</param>
	/// <param name="Max">The maximum number of times to reduce the expression</param>
	/// <returns>The reduced expression</returns>
	public static ILambdaExpression Reduce(ILambdaExpression expression, ulong Max)
	{
		ulong counter = 0;
		// Reduce the expression
		return Reduce(expression, ref counter, Max);
	}

	/// <summary>
	/// Reduces the expression a maximum number of times
	/// </summary>
	/// <param name="expression">The expression to reduce</param>
	/// <param name="Counter">The number of times the expression has been reduced</param>
	/// <param name="Max">The maximum number of times to reduce the expression</param>
	/// <returns></returns>
	private static ILambdaExpression Reduce(ILambdaExpression expression, ref ulong Counter, ulong Max)
	{
		// If the counter is greater than the maximum, return the expression
		if (Counter++ > Max)
			return expression;

		// Else increase the counter
		Counter++;

		// Reduce the expression
		//ILambdaExpression reduced = expression.Reduce();

		// For now just fix the alpha stuff
		ILambdaExpression reduced = expression;

		Console.WriteLine("Got the following conflicting variables:");
        Console.WriteLine(string.Join(", ", reduced.GetConflictVariables().Select(lambdaVariable => lambdaVariable.Name)) + ".");

		reduced.ResolveConflicts();

		// If the expression is the same as the reduced expression, return the reduced expression
		if (Equals(expression, reduced))
			return reduced;

		// If the reduced expression is just a variable, return a function that returns the variable
		if (reduced is LambdaVariable variable)
			return new LambdaAbstraction(variable, variable);

		// Otherwise, reduce the reduced expression
		return Reduce(reduced, ref Counter, Max);
	}
}
