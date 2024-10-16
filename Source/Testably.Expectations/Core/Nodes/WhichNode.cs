using System;

namespace Testably.Expectations.Core.Nodes;

internal class WhichNode<TSource, TProperty> : ManipulationNode
{
	private readonly PropertyAccessor _propertyAccessor;
	public override Node Inner { get; set; }

	public WhichNode(PropertyAccessor propertyAccessor, Node inner)
	{
		_propertyAccessor = propertyAccessor;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TExpectation>(TExpectation? actual, Exception? exception)
		where TExpectation : default
	{
		if (_propertyAccessor is PropertyAccessor<TSource, TProperty> propertyAccessor)
		{
			if (actual is not TSource matchingActualValue)
			{
				throw new InvalidOperationException($"The property type for the actual value in the which node did not match. Expected {typeof(TSource).Name}, but found {actual?.GetType().Name}");
			}
			if (propertyAccessor.TryAccessProperty(matchingActualValue, out var matchingValue))
			{
				return Inner.IsMetBy(matchingValue, exception)
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
