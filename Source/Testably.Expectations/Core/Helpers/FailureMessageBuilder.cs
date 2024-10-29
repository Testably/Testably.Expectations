using System.Text;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Core.Helpers;

internal class FailureMessageBuilder : IFailureMessageBuilder
{
	public StringBuilder ExpressionBuilder { get; }
	private readonly string _subject;

	public FailureMessageBuilder(string subject)
	{
		_subject = subject;
		ExpressionBuilder = new StringBuilder();
		ExpressionBuilder
			.Append(nameof(Expect))
			.Append(".")
			.Append(nameof(Expect.That))
			.Append("(")
			.Append(_subject)
			.Append(")");
	}

	#region IFailureMessageBuilder Members

	public string FromFailure(ConstraintResult.Failure failure)
	{
		return $"""
		        Expected {_subject} to
		        {failure.ExpectationText},
		        but {failure.ResultText}
		        at {ExpressionBuilder}
		        """;
	}

	#endregion
}
