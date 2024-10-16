using System.Text;

namespace Testably.Expectations.Core;

internal class FailureMessageBuilder : IFailureMessageBuilder
{
	private string _subject;

	public FailureMessageBuilder(string subject)
	{
		_subject = subject;
		ExpressionBuilder = new();
		ExpressionBuilder
			.Append(nameof(Expect))
			.Append(".")
			.Append(nameof(Expect.That))
			.Append("(")
			.Append(_subject)
			.Append(")");
	}

	public StringBuilder ExpressionBuilder { get; }

	public string FromFailure(ExpectationResult.Failure failure)
	{
		return $"""
			Expected that {_subject}
			{failure.ExpectationText},
			but {failure.ResultText}
			at {ExpressionBuilder}
			""";
	}
}
