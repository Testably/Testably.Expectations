using System.Text;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Core.Helpers;

internal class FailureMessageBuilder : IFailureMessageBuilder
{
	public StringBuilder ExpressionBuilder { get; }

	public FailureMessageBuilder(string subjectExpression)
	{
		ExpressionBuilder = new StringBuilder();
		ExpressionBuilder
			.Append(nameof(Expect))
			.Append('.')
			.Append(nameof(Expect.That))
			.Append('(')
			.Append(subjectExpression)
			.Append(')');
	}

	#region IFailureMessageBuilder Members

	public string FromFailure(string subject, ConstraintResult.Failure failure)
		=> $"""
		    Expected {subject} to
		    {failure.ExpectationText},
		    but {failure.ResultText}
		    at {ExpressionBuilder}
		    """;

	#endregion
}
