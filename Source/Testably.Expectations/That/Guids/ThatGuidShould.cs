﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Guid" /> values.
/// </summary>
public static partial class ThatGuidShould
{
	/// <summary>
	///     Start expectations for current <see cref="Guid" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<Guid> Should(this IExpectSubject<Guid> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	private readonly struct ValueConstraint(string expectation, Func<Guid, bool> successIf)
		: IValueConstraint<Guid>
	{
		public ConstraintResult IsMetBy(Guid actual)
		{
			if (successIf(actual))
			{
				return new ConstraintResult.Success<Guid?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
