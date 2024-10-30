using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations.Core;

/// <summary>
///     The failure message builder.
/// </summary>
internal interface IFailureMessageBuilder
{
	/// <summary>
	///     Creates the exception message from the <paramref name="failure" />.
	/// </summary>
	string FromFailure(ConstraintResult.Failure failure);
}
