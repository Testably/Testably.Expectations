using System;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Nodes;

internal class WhichNode<TProperty> : Node
{
	public Node Inner { get; }

	public string Property { get; }

	public WhichNode(string property, Node inner)
	{
		Property = property;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TExpectation>(TExpectation actual)
	{
		object? propertyValue = ExpressionHelpers.GetPropertyValue(actual, Property);
		if (propertyValue is TProperty matchingValue)
		{
			return Inner.IsMetBy(matchingValue)
				.UpdateExpectationText(r => $".{Property} {r.ExpectationText}");
		}

		throw new InvalidOperationException($"The property type for the which node did not match. Expected {typeof(TProperty).Name}, but found {propertyValue?.GetType().Name}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $".{Property} {Inner}";
}
