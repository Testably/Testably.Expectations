using System.Diagnostics;
using Testably.Expectations.Core;
using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations;

/// <summary>
///     Starting point for defining expectations.
/// </summary>
[StackTraceHidden]
public static class Should
{
	/// <summary>
	///     Expect the actual value to be...
	/// </summary>
	public static ShouldBe Be => new(new SimpleExpectationBuilder());

	/// <summary>
	///     Expect the actual value to end...
	/// </summary>
	public static ShouldEnd End => new(new SimpleExpectationBuilder());

	/// <summary>
	///     Expect the actual value to start...
	/// </summary>
	public static ShouldStart Start => new(new SimpleExpectationBuilder());

	/// <summary>
	///     Expect the actual value to throw...
	/// </summary>
	public static ShouldThrow Throw => new(new SimpleExpectationBuilder());
}
