namespace Testably.Expectations.Core;

public interface IFailureMessageBuilder
{
	string FromFailure(ExpectationResult.Failure failure);
}
