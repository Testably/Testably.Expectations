﻿using Testably.Expectations.Core;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatBoolShould
{
	/// <summary>
	///     Verifies that the subject is <see langword="false" />.
	/// </summary>
	public static AndOrResult<bool, IThat<bool>> BeFalse(this IThat<bool> source)
		=> new(source.ExpectationBuilder
				.AddConstraint(it => new BeValueConstraint(it, false)),
			source);
}
