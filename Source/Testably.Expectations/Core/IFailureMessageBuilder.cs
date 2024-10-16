namespace Testably.Expectations.Core;

internal interface IFailureMessageBuilder
{
	string FromFailure(ExpectationResult.Failure failure);
}
