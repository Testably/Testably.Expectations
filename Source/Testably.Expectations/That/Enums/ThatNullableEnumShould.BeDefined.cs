using System;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableEnumShould
{
	/// <summary>
	///     Verifies that the subject is defined inside the <typeparamref name="TEnum" />.
	/// </summary>
	public static AndOrExpectationResult<TEnum?, IThat<TEnum?>> BeDefined<TEnum>(
		this IThat<TEnum?> source)
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint<TEnum>(
					"be defined",
					actual => actual != null && Enum.IsDefined(typeof(TEnum), actual.Value)))
				.AppendMethodStatement(nameof(BeDefined)),
			source);

	/// <summary>
	///     Verifies that the subject is not defined inside the <typeparamref name="TEnum" />.
	/// </summary>
	public static AndOrExpectationResult<TEnum?, IThat<TEnum?>> NotBeDefined<TEnum>(
		this IThat<TEnum?> source)
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint<TEnum>(
					"not be defined",
					actual => actual != null && !Enum.IsDefined(typeof(TEnum), actual.Value)))
				.AppendMethodStatement(nameof(NotBeDefined)),
			source);
}
