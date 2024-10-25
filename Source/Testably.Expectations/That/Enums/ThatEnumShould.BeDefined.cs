using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumShould
{
	/// <summary>
	///     Verifies that the subject is defined inside the <typeparamref name="TEnum" />.
	/// </summary>
	public static AndOrExpectationResult<TEnum, IThat<TEnum>> BeDefined<TEnum>(
		this IThat<TEnum> source)
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					"be defined",
					actual => Enum.IsDefined(typeof(TEnum), actual)),
				b => b.AppendMethod(nameof(BeDefined))),
			source);

	/// <summary>
	///     Verifies that the subject is not defined inside the <typeparamref name="TEnum" />.
	/// </summary>
	public static AndOrExpectationResult<TEnum, IThat<TEnum>> NotBeDefined<TEnum>(
		this IThat<TEnum> source)
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					"not be defined",
					actual => !Enum.IsDefined(typeof(TEnum), actual)),
				b => b.AppendMethod(nameof(NotBeDefined))),
			source);
}
