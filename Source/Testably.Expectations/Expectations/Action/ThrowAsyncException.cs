using System;
using System.Linq;
using System.Threading.Tasks;
using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations.Action;

internal class ThrowAsyncException<TException> : IAsyncExpectation<Func<Task>, TException>
	where TException : Exception
{
	#region IExpectation<Action,TException> Members

	/// <inheritdoc />
	public async Task<ExpectationResult> IsMetByAsync(Func<Task>? actual)
	{
		try
		{
			if (actual != null)
			{
				await actual();
			}
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

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to throw {PrependArticle(typeof(TException).Name)}";

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
