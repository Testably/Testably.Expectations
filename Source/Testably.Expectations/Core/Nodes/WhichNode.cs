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
	public override ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		object? propertyValue = ExpressionHelpers.GetPropertyValue(actual, Property);
		if (propertyValue is TProperty matchingValue)
		{
			return Inner.ApplyTo(matchingValue)
				.UpdateExpectationText(r => $".{Property} {r.ExpectationText}");
		}

		return Inner.ApplyTo(propertyValue)
			.UpdateExpectationText(r => $".{Property} {r.ExpectationText}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $".{Property} {Inner}";
}
