using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Testably.Expectations.Core.ExpectationBuilders;

internal class WhichExpectationBuilder<TExpectation, TProperty> : IExpectationBuilder
{
	private readonly Expectation<TProperty> _expectation;
	private readonly IExpectationBuilder _expectationBuilder;
	private readonly Expression<Func<TExpectation, TProperty>> _propertySelector;

	public WhichExpectationBuilder(IExpectationBuilder expectationBuilder,
		Expression<Func<TExpectation, TProperty>> propertySelector,
		Expectation<TProperty> expectation)
	{
		_expectationBuilder = expectationBuilder;
		_propertySelector = propertySelector;
		_expectation = expectation;
	}

	#region IExpectationBuilder Members

	/// <inheritdoc />
	public IExpectationBuilder Add(IExpectation expectation)
	{
		throw new NotImplementedException();
	}

	public ExpectationResult ApplyTo<T>(T actual)
	{
		var outerResult = _expectationBuilder.ApplyTo(actual);
		if (outerResult is not ExpectationResult.Success<TExpectation> outerResult2)
		{
			return outerResult;
		}

		if (_propertySelector.Body is not MemberExpression member)
		{
			throw new ArgumentException(string.Format(
				"Expression '{0}' refers to a method, not a property.",
				_propertySelector));
		}

		if (member.Member is not PropertyInfo propInfo)
		{
			throw new ArgumentException(string.Format(
				"Expression '{0}' refers to a field, not a property.",
				_propertySelector));
		}

		Type type = typeof(TExpectation);
		if (propInfo.ReflectedType != null && type != propInfo.ReflectedType &&
			!type.IsSubclassOf(propInfo.ReflectedType))
		{
			throw new ArgumentException(string.Format(
				"Expression '{0}' refers to a property that is not from type {1}.",
				_propertySelector,
				type));
		}

		object? propertyValue = propInfo.GetValue(outerResult2.Value);
		if (propertyValue is TProperty castedPropertyValue)
		{
			ExpectationResult result = _expectation.ApplyTo(castedPropertyValue);
			return ExpectationResult.Copy(result, castedPropertyValue, f => $"property '{propInfo.Name}' {f.ExpectationText}");
		}

		return new ExpectationResult.Failure("failed", "");
	}

	#endregion
}
