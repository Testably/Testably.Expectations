using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableEnumShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<TEnum?, IThat<TEnum?>> BeNull<TEnum>(
		this IThat<TEnum?> source)
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					"be null",
					actual => actual == null),
				b => b.AppendMethod(nameof(BeNull))),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<TEnum?, IThat<TEnum?>> NotBeNull<TEnum>(
		this IThat<TEnum?> source)
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					"not be null",
					actual => actual != null),
				b => b.AppendMethod(nameof(NotBeNull))),
			source);
}
