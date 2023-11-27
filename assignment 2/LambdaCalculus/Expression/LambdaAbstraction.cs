using System.Xml.Linq;

namespace LambdaCalculus.Lambda;

/// <summary>
/// Represents a lambda abstraction
/// </summary>
public class LambdaAbstraction : ILambdaExpression
{
	/// <summary>
	/// The name of the variable
	/// </summary>
	public LambdaVariable Name { get; set; }

	/// <summary>
	/// The body of the abstraction
	/// </summary>
	public ILambdaExpression Body { get; set; }

	/// <summary>
	/// Creates a new lambda abstraction
	/// </summary>
	/// <param name="name">The name of the variable</param>
	/// <param name="body">The body of the abstraction</param>
	public LambdaAbstraction(LambdaVariable name, ILambdaExpression body)
	{
		Name = name;
		Body = body;
	}

	/// <summary>
	/// Reduces the expression
	/// </summary>
	/// <returns>The reduced expression</returns>
	public ILambdaExpression Reduce() =>
		// Beta reduction for lambda abstraction
		new LambdaAbstraction(Name, Body.Reduce());


	/// <summary>
	/// Substitutes all instances of the variable with the replacement
	/// </summary>
	/// <param name="variable">The variable to substitute</param>
	/// <param name="replacement">The replacement</param>
	/// <returns>The substituted expression</returns>
	public ILambdaExpression Substitute(LambdaVariable variable, ILambdaExpression replacement)
    {
        // Perform substitution in the body of the abstraction
        if (Name.Equals(variable))
            // Avoid variable capture by renaming if necessary
            return this;
        else
            return new LambdaAbstraction(Name, Body.Substitute(variable, replacement));
    }
}
