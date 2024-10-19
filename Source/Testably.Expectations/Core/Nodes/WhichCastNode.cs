﻿using System;
using System.Threading.Tasks;

namespace Testably.Expectations.Core.Nodes;

internal class WhichCastNode<TSource, TBase, TProperty> : ManipulationNode
	where TProperty : TBase
{
	public override Node Inner { get; set; }
	private readonly PropertyAccessor _propertyAccessor;
	private readonly IExpectation<TBase, TProperty> _cast;
	private readonly string _textSeparator;

	public WhichCastNode(PropertyAccessor propertyAccessor,
		IExpectation<TBase, TProperty> cast,
		Node inner,
		string textSeparator = " which ")
	{
		_propertyAccessor = propertyAccessor;
		_cast = cast;
		_textSeparator = textSeparator;
		Inner = inner;
	}

	/// <inheritdoc />
	public override async Task<ExpectationResult> IsMetBy<TValue>(SourceValue<TValue> value)
		where TValue : default
	{
		if (_propertyAccessor is PropertyAccessor<TSource, TBase> propertyAccessor)
		{
			if (value.Value is not TSource typedValue)
			{
				throw new InvalidOperationException(
					$"The property type for the actual value in the which node did not match.{Environment.NewLine}Expected {typeof(TSource).Name},{Environment.NewLine}but found {value.Value?.GetType().Name}");
			}

			if (propertyAccessor.TryAccessProperty(new SourceValue<TSource>(typedValue, value.Exception),
				out TBase? baseValue))
			{
				var castedResult = _cast.IsMetBy(baseValue, value.Exception);
				if (castedResult is ExpectationResult.Success success &&
				    success.TryGetValue<TProperty>(out var matchingValue))
				{
					return (await Inner.IsMetBy(new SourceValue<TProperty>(matchingValue, value.Exception)))
						.UpdateExpectationText(r => $"{_textSeparator}{_propertyAccessor}{r.ExpectationText}");
				}

				var failure = await Inner.IsMetBy(new SourceValue<TProperty>(default, value.Exception));
				return castedResult.UpdateExpectationText(_ => $"{_textSeparator}{_propertyAccessor}{failure.ExpectationText}");
			}

			throw new InvalidOperationException(
				$"The property type for the which node did not match.{Environment.NewLine}Expected {typeof(TBase).Name},{Environment.NewLine}but found {baseValue?.GetType().Name}");
		}

		throw new InvalidOperationException(
			$"The property accessor for the which node did not match.{Environment.NewLine}Expected {typeof(PropertyAccessor<TValue, TProperty>).FullName},{Environment.NewLine}but found {_propertyAccessor.GetType().FullName}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $".{_propertyAccessor} {Inner}";
}
