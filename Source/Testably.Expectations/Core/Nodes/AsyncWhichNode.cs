using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Nodes;

internal class AsyncWhichNode<TSource, TProperty> : ManipulationNode
{
	private readonly AsyncPropertyAccessor _propertyAccessor;
	public override Node Inner { get; set; }

	public AsyncWhichNode(AsyncPropertyAccessor propertyAccessor, Node inner)
	{
		_propertyAccessor = propertyAccessor;
		Inner = inner;
	}

	/// <inheritdoc />
	public override ExpectationResult IsMetBy<TExpectation>(TExpectation actual)
	{
		throw new InvalidOperationException(
			$"The expectation '{ToString()}' can only be used asynchronously.");
	}

	/// <inheritdoc />
	public override async Task<ExpectationResult> IsMetByAsync<TExpectation>(TExpectation actual)
	{
		if (_propertyAccessor is AsyncPropertyAccessor<TSource, TProperty> propertyAccessor)
		{
			if (actual is not TSource matchingActualValue)
			{
				throw new InvalidOperationException($"The property type for the actual value in the which node did not match. Expected {typeof(TSource).Name}, but found {actual?.GetType().Name}");
			}

			var matchingValue = await propertyAccessor.TryAccessProperty(matchingActualValue);
			return (await Inner.IsMetByAsync(matchingValue))
				.UpdateExpectationText(r => $".{_propertyAccessor} {r.ExpectationText}");
		}

		throw new InvalidOperationException($"The property accessor for the which node did not match. Expected {typeof(PropertyAccessor<TExpectation, TProperty>).FullName}, but found {_propertyAccessor.GetType().FullName}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $".{_propertyAccessor} {Inner}";
}
