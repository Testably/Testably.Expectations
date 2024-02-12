using System.Diagnostics;
using Testably.Expectations.Core;

namespace Testably.Expectations;

/// <summary>
///     The starting point for defining expectations.
/// </summary>
[StackTraceHidden]
public static class Should
{
	/// <summary>
	///     Expect the actual value to be…
	/// </summary>
	public static ShouldBe Be => new(new ExpectationBuilder());

	/// <summary>
	///     Expect the actual value to contain…
	/// </summary>
	public static ShouldContain Contain => new(new ExpectationBuilder());

	/// <summary>
	///     Expect the actual value to end…
	/// </summary>
	public static ShouldEnd End => new(new ExpectationBuilder());

	/// <summary>
	///     Negates the remaining expectation.
	/// </summary>
	public static ExpectationShould Not => new(new ExpectationBuilder().Not());

	/// <summary>
	///     Expect the actual value to start…
	/// </summary>
	public static ShouldStart Start => new(new ExpectationBuilder());

	/// <summary>
	///     Expect the actual value to throw…
	/// </summary>
	public static ShouldThrow Throw => new(new ExpectationBuilder());
}
