using Testably.Expectations.Constraints.String;
using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static class StringExtensions
{
	public static Expectation<string?> With(this ShouldStart shouldStart, string expected)
		=> shouldStart.WithConstraint(new StartsWithConstraint(expected));

	public static Expectation<string?> With(this ShouldEnd shouldEnd, string expected)
		=> shouldEnd.WithConstraint(new EndsWithConstraint(expected));
}
