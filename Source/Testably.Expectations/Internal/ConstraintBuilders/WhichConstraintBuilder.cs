using System;
using System.Linq.Expressions;
using System.Reflection;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Internal;

namespace Testably.Expectations.Internal.ConstraintBuilders;

internal class WhichConstraintBuilder<TExpectation, TProperty> : IConstraintBuilder
{
	private readonly Expectation<TProperty> _constraint;
	private readonly Expression<Func<TExpectation, TProperty>> _propertySelector;

	public WhichConstraintBuilder(Expression<Func<TExpectation, TProperty>> propertySelector,
		Expectation<TProperty> constraint)
	{
		_propertySelector = propertySelector;
		_constraint = constraint;
	}

	#region IConstraintBuilder Members

	public IConstraintBuilder Add(IConstraint constraint) => throw new NotImplementedException();

	public ExpectationResult ApplyTo<T>(T actual)
	{
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

		object? propertyValue = propInfo.GetValue(actual);
		if (propertyValue is TProperty castedPropertyValue)
		{
			ExpectationResult result = _constraint.ApplyTo(castedPropertyValue);
			return new ExpectationResult($"property '{propInfo.Name}' {result.ExpectationText}",
				result.IsSuccess);
		}

		return new ExpectationResult("failed", false);
	}

	#endregion
}
