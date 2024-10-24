using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Core.Nodes;

internal class WhichNode<TSource, TProperty> : ManipulationNode
{
	public override Node Inner { get; set; }
	private readonly PropertyAccessor _propertyAccessor;
	private readonly string _textSeparator;

	public WhichNode(PropertyAccessor propertyAccessor, Node inner,
		string textSeparator = " which ")
	{
		_propertyAccessor = propertyAccessor;
		_textSeparator = textSeparator;
		Inner = inner;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(SourceValue<TValue> value, IEvaluationContext context)
		where TValue : default
	{
		if (_propertyAccessor is PropertyAccessor<TSource, TProperty> propertyAccessor)
		{
			if (value.Value is not TSource typedValue)
			{
				throw new InvalidOperationException(
					$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TSource).Name},{Environment.NewLine}but found {value.Value?.GetType().Name}");
			}

			if (propertyAccessor.TryAccessProperty(
				new SourceValue<TSource>(typedValue, value.Exception),
				out TProperty? matchingValue))
			{
				return (await Inner.IsMetBy(
						new SourceValue<TProperty>(matchingValue, value.Exception), context))
					.UpdateExpectationText(r
						=> $"{_textSeparator}{_propertyAccessor}{r.ExpectationText}");
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
