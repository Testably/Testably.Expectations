using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Text;

namespace Testably.Expectations.Core.ExpectationBuilders;

[StackTraceHidden]
internal class WhichExpectationBuilder<TSource, TProperty> : IExpectationBuilder
{
	private readonly Func<TProperty, ExpectationResult> _expectation;
	private readonly IExpectationBuilder _expectationBuilder;
	private readonly string _propertySelector;

	public WhichExpectationBuilder(IExpectationBuilder expectationBuilder,
		Expression<Func<TSource, TProperty>> propertySelector,
		Expectation<TProperty> expectation)
	{
		_expectationBuilder = expectationBuilder;
		_propertySelector = GetPropertyPath(propertySelector);
		_expectation = expectation.ApplyTo;
	}

	public WhichExpectationBuilder(IExpectationBuilder expectationBuilder,
		Expression<Func<TSource, TProperty>> propertySelector,
		NullableExpectation<TProperty> expectation)
	{
		_expectationBuilder = expectationBuilder;
		_propertySelector = GetPropertyPath(propertySelector);
		_expectation = expectation.ApplyTo;
	}

	#region IExpectationBuilder Members

	/// <inheritdoc cref="IExpectationBuilder.ApplyTo{TExpectation}(TExpectation)" />
	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult expectationResult = _expectationBuilder.ApplyTo(actual);
		if (expectationResult is not ExpectationResult.Success<TSource> successResult)
		{
			return expectationResult;
		}

		object? propertyValue = GetPropertyValue(successResult.Value, _propertySelector);
		if (propertyValue is not TProperty castedPropertyValue)
		{
			throw new ArgumentException(
				$"The property at '{_propertySelector}' is not of type {typeof(TProperty).Name}");
		}

		ExpectationResult result = _expectation.Invoke(castedPropertyValue);
		return ExpectationResult.Copy(result, castedPropertyValue,
			f => $".{_propertySelector} {f.ExpectationText}");
	}

	#endregion

	public static object? GetPropertyValue(object? obj, string propertyPath)
	{
		if (propertyPath.IndexOf(".", StringComparison.Ordinal) < 0)
		{
			Type? objType = obj?.GetType();
			return objType?.GetProperty(propertyPath)?.GetValue(obj, null);
		}

		object? propertyValue = obj;
		foreach (string propertyName in propertyPath.Split('.'))
		{
			propertyValue = GetPropertyValue(propertyValue, propertyName);
		}

		return propertyValue;
	}

	private static MemberExpression? GetMemberExpression(Expression? expression)
		=> expression switch
		{
			MemberExpression memberExpression => memberExpression,
			LambdaExpression lambdaExpression => lambdaExpression.Body switch
			{
				MemberExpression body => body,
				UnaryExpression unaryExpression => (MemberExpression)unaryExpression.Operand,
				_ => null
			},
			_ => null
		};

	private static string GetPropertyPath(Expression<Func<TSource, TProperty>> expression)
	{
		MemberExpression? memberExpression = GetMemberExpression(expression.Body);
		if (memberExpression == null)
		{
			if (expression.Body is UnaryExpression castExpression)
			{
				throw new ArgumentException(
					$"Expression '{castExpression.Operand}' does not refer to a property.");
			}

			throw new ArgumentException(
				$"Expression '{expression.Body}' does not refer to a property.");
		}

		StringBuilder path = new();
		while (memberExpression != null)
		{
			if (path.Length > 0)
			{
				path.Insert(0, ".");
			}

			path.Insert(0, memberExpression.Member.Name);
			memberExpression = GetMemberExpression(memberExpression.Expression);
		}

		return path.ToString();
	}
}
