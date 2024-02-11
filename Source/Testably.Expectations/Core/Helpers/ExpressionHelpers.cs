using System;
using System.Linq.Expressions;
using System.Text;

namespace Testably.Expectations.Core.Helpers;

internal static class ExpressionHelpers
{
	public static MemberExpression? GetMemberExpression(Expression? expression)
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

	public static string GetPropertyPath(Expression expression)
	{
		MemberExpression? memberExpression = GetMemberExpression(expression);
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

	public static object? GetPropertyValue(object? obj, string propertyPath)
	{
		if (propertyPath.IndexOf('.', StringComparison.Ordinal) < 0)
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
}
