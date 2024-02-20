using System;
using System.Linq;
using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations.Action;

internal class ConditionallyThrowException<TException> : IExpectation<System.Action, TException>
	where TException : Exception
{
	private readonly bool _predicate;
	private readonly string _predicateExpression;

	public ConditionallyThrowException(bool predicate, string predicateExpression)
	{
		_predicate = predicate;
		_predicateExpression = predicateExpression;
	}

	#region IExpectation<Action,TException> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(System.Action actual)
	{
		if (_predicate)
		{
			try
			{
				actual?.Invoke();
			}
			catch (TException ex)
			{
				return new ExpectationResult.Success<TException>(ex, ToString());
			}
			catch (Exception ex)
			{
				return new ExpectationResult.Failure<Exception>(ex, ToString(),
					$"the thrown exception was {PrependArticle(ex.GetType().Name)} with message '{ex.Message}'");
			}

			return new ExpectationResult.Failure(ToString(), "none was thrown");
		}
		try
		{
			actual?.Invoke();
		}
		catch (TException ex)
		{
			return new ExpectationResult.Failure<TException>(ex, ToString(), $"{PrependArticle(typeof(TException).Name)} was thrown");
		}
		catch (Exception ex)
		{
			return new ExpectationResult.Success<Exception>(ex, ToString());
		}

		return new ExpectationResult.Success<System.Action>(actual, ToString());
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to only throw {PrependArticle(typeof(TException).Name)} when {_predicateExpression}";

	private static string PrependArticle(string name)
	{
		char[] vocals = ['a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U'];
		if (vocals.Contains(name[0]))
		{
			return $"an {name}";
		}

		return $"a {name}";
	}
}
