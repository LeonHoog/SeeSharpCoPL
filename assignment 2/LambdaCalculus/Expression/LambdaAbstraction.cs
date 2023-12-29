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

	public IEnumerable<LambdaVariable> GetBoundVariables() =>
		Body.GetBoundVariables().Append(Name);

	public IEnumerable<LambdaVariable> GetConflictVariables()
	{
		// Get the bound variables of the body
		IEnumerable<LambdaVariable> boundVariables = Body.GetBoundVariables();

		// Empty enumerable of conflict variables
		IEnumerable<LambdaVariable> conflictVariables = Enumerable.Empty<LambdaVariable>();

		// If the name is in the bound variables, append the name to the conflict variables
		if (boundVariables.Contains(Name))
			conflictVariables = conflictVariables.Append(Name);

		// Return the conflict variables
		return conflictVariables.Concat(Body.GetConflictVariables());
	}


	public void ResolveConflicts()
	{
		while (Body.GetBoundVariables().Contains(Name))
			Name.Name += "'";

		Body.ResolveConflicts();
	}
}
