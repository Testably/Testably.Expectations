using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableBoolShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> Be(this IThat<bool?> source,
		bool? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsValueConstraint(expected))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<bool?, IThat<bool?>> NotBe(this IThat<bool?> source,
		bool? unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new IsNotValueConstraint(unexpected))
				.AppendMethodStatement(nameof(NotBe), doNotPopulateThisValue),
			source);
}
