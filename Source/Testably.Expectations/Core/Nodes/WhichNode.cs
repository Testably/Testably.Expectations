using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.Core.Nodes;

internal class WhichNode<TSource, TProperty> : ManipulationNode
{
	public override Node Inner { get; set; }
	private readonly PropertyAccessor _propertyAccessor;
	private readonly Func<PropertyAccessor, string, string> _expectationTextGenerator;

	public WhichNode(PropertyAccessor propertyAccessor, Node inner,
		Func<PropertyAccessor, string, string>? expectationTextGenerator = null)
	{
		_propertyAccessor = propertyAccessor;
		_expectationTextGenerator = expectationTextGenerator ?? DefaultExpectationTextGenerator;
		Inner = inner;
	}

	private string DefaultExpectationTextGenerator(PropertyAccessor propertyAccessor, string expectationText)
	{
		return propertyAccessor + expectationText;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(
		TValue? value,
		IEvaluationContext context)
		where TValue : default
	{
		if (_propertyAccessor is PropertyAccessor<TSource, TProperty> propertyAccessor)
		{
			if (value is not TSource typedValue)
			{
				throw new InvalidOperationException(
					$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TSource).Name},{Environment.NewLine}but found {value?.GetType().Name}");
			}

			if (propertyAccessor.TryAccessProperty(
				typedValue,
				out TProperty? matchingValue))
			{
				var result = (await Inner.IsMetBy(matchingValue, context))
					.UpdateExpectationText(r
						=> _expectationTextGenerator(_propertyAccessor, r.ExpectationText));
				return result.UseValue(value);
			}

			throw new InvalidOperationException(
				$"The property type for the which node did not match.{Environment.NewLine}Expected {typeof(TProperty).Name},{Environment.NewLine}but found {matchingValue?.GetType().Name}");
		}

		throw new InvalidOperationException(
			$"The property accessor for the which node did not match.{Environment.NewLine}Expected {typeof(PropertyAccessor<TValue, TProperty>).FullName},{Environment.NewLine}but found {_propertyAccessor.GetType().FullName}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $".{_propertyAccessor} {Inner}";
}
