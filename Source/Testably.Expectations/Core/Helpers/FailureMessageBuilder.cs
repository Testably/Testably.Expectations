using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Core.Helpers;

internal class FailureMessageBuilder : IFailureMessageBuilder
{
	#region IFailureMessageBuilder Members

	public string FromFailure(string subject, ConstraintResult.Failure failure)
		=> $"""
		    Expected {subject} to
		    {failure.ExpectationText},
		    but {failure.ResultText}
		    """;

	#endregion
}
