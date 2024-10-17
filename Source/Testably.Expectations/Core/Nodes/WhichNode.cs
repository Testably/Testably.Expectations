using System;

namespace Testably.Expectations.Core.Nodes;

internal class WhichNode<TSource, TProperty> : ManipulationNode
{
	public override Node Inner { get; set; }
	private readonly PropertyAccessor _propertyAccessor;

	public WhichNode(PropertyAccessor propertyAccessor, Node inner)
	{
		_propertyAccessor = propertyAccessor;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		if (_propertyAccessor is PropertyAccessor<TSource, TProperty> propertyAccessor)
		{
			if (value is not SourceValue<TSource> matchingActualValue)
			{
				throw new InvalidOperationException(
					$"The property type for the actual value in the which node did not match. Expected {typeof(TSource).Name}, but found {value.Value?.GetType().Name}");
			}

			if (propertyAccessor.TryAccessProperty(matchingActualValue,
				out TProperty? matchingValue))
			{
				return Inner.IsMetBy(value)
					.UpdateExpectationText(r => $"{_propertyAccessor}{r.ExpectationText}");
			}

			throw new InvalidOperationException(
				$"The property type for the which node did not match. Expected {typeof(TProperty).Name}, but found {matchingValue?.GetType().Name}");
		}

		throw new InvalidOperationException(
			$"The property accessor for the which node did not match. Expected {typeof(PropertyAccessor<TValue, TProperty>).FullName}, but found {_propertyAccessor.GetType().FullName}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $".{_propertyAccessor} {Inner}";
}
