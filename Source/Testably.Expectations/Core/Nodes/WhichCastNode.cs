using System;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.EvaluationContext;

namespace Testably.Expectations.Core.Nodes;

internal class WhichCastNode<TSource, TBase, TProperty> : ManipulationNode
	where TProperty : TBase
{
	public override Node Inner { get; set; }
	private readonly ICastConstraint<TBase, TProperty> _cast;
	private readonly PropertyAccessor _propertyAccessor;
	private readonly string _textSeparator;

	public WhichCastNode(PropertyAccessor propertyAccessor,
		ICastConstraint<TBase, TProperty> cast,
		Node inner,
		string textSeparator = " which ")
	{
		_propertyAccessor = propertyAccessor;
		_cast = cast;
		_textSeparator = textSeparator;
		Inner = inner;
	}

	/// <inheritdoc />
	public override async Task<ConstraintResult> IsMetBy<TValue>(
		TValue? value,
		IEvaluationContext context)
		where TValue : default
	{
		if (_propertyAccessor is PropertyAccessor<TSource, TBase> propertyAccessor)
		{
			if (value is not TSource typedValue)
			{
				throw new InvalidOperationException(
					$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TSource).Name},{Environment.NewLine}but found {value?.GetType().Name}");
			}

			await Task.Yield();
			//TODO VAB
			//if (propertyAccessor.TryAccessProperty(typedValue,
			//	out TBase? baseValue))
			//{
			//	ConstraintResult? castedResult = _cast.IsMetBy(baseValue);
			//	if (castedResult is ConstraintResult.Success success &&
			//	    success.TryGetValue(out TProperty? matchingValue))
			//	{
			//		ConstraintResult? result = (await Inner.IsMetBy(matchingValue, context))
			//			.UpdateExpectationText(r
			//				=> $"{_textSeparator}{_propertyAccessor}{r.ExpectationText}");
			//		return result.UseValue(value);
			//	}
//
			//	ConstraintResult? failure =
			//		await Inner.IsMetBy(value.Exception,
			//			context);
			//	return castedResult.UpdateExpectationText(_
			//		=> $"{_textSeparator}{_propertyAccessor}{failure.ExpectationText}");
			//}

			throw new InvalidOperationException(
				$"The property type for the which node did not match.{Environment.NewLine}Expected {typeof(TBase).Name},{Environment.NewLine}but found {value?.GetType().Name}");
		}

		throw new InvalidOperationException(
			$"The property accessor for the which node did not match.{Environment.NewLine}Expected {typeof(PropertyAccessor<TValue, TProperty>).FullName},{Environment.NewLine}but found {_propertyAccessor.GetType().FullName}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $".{_propertyAccessor} {Inner}";
}
