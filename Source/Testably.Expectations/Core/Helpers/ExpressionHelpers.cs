using System.Linq.Expressions;

namespace Testably.Expectations.Core.Helpers;

internal static class ExpressionHelpers
{
	public static string ExtractExpressionName(Expression expression, string? parameterName = null)
	{
		if (expression is LambdaExpression lambdaExpression)
		{
			if (parameterName == null && lambdaExpression.Parameters.Count > 0)
			{
				parameterName = lambdaExpression.Parameters[0].Name;
			}
			if (lambdaExpression.Body is UnaryExpression unaryExpression)
			{
				return ExtractExpressionName(unaryExpression.Operand, parameterName);
			}
			return ExtractExpressionName(lambdaExpression.Body, parameterName);
		}

		if (expression is MemberExpression memberExpression)
		{
			var name = memberExpression.ToString();
			if (parameterName != null &&
			    name.StartsWith($"{parameterName}."))
			{
				name = name.Substring(parameterName.Length + 1);
			}

			return name;
		}


		return expression.ToString();
	}
}
