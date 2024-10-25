﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatGuidShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<Guid, That<Guid>> Be(this That<Guid> source,
		Guid expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"be {Formatter.Format(expected)}",
					actual => actual.Equals(expected)),
				b => b.AppendMethod(nameof(Be), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<Guid, That<Guid>> NotBe(this That<Guid> source,
		Guid unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new Constraint(
					$"not be {Formatter.Format(unexpected)}",
					actual => !actual.Equals(unexpected)),
				b => b.AppendMethod(nameof(NotBe), doNotPopulateThisValue)),
			source);
}