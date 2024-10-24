﻿using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="false" />.
	/// </summary>
	public static AndOrExpectationResult<bool, That<bool>> BeFalse(this That<bool> source)
		=> new(source.ExpectationBuilder.Add(new IsConstraint(false),
				b => b.AppendMethod(nameof(BeFalse))),
			source);
}