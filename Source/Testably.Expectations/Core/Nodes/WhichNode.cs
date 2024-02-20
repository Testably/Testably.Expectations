using System;

namespace Testably.Expectations.Core.Nodes;

internal class WhichNode<TProperty> : Node
{
	private readonly PropertyAccessor _propertyAccessor;
	public Node Inner { get; }

	public WhichNode(PropertyAccessor propertyAccessor, Node inner)
	{
		_propertyAccessor = propertyAccessor;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TExpectation>(TExpectation actual)
	{
		if (_propertyAccessor is PropertyAccessor<TExpectation, TProperty> propertyAccessor)
		{
			if (propertyAccessor.TryAccessProperty(actual, out var matchingValue))
			{
				return Inner.IsMetBy(matchingValue)
					.UpdateExpectationText(r => $".{_propertyAccessor} {r.ExpectationText}");
			}

			throw new InvalidOperationException($"The property type for the which node did not match. Expected {typeof(TProperty).Name}, but found {matchingValue?.GetType().Name}");
		}

		throw new InvalidOperationException($"The property accessor for the which node did not match. Expected {typeof(PropertyAccessor<TExpectation, TProperty>).FullName}, but found {_propertyAccessor.GetType().FullName}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $".{_propertyAccessor} {Inner}";
}
