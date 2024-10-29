﻿using System;
using System.IO;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="Stream" /> values.
/// </summary>
public static partial class ThatStreamShould
{
	/// <summary>
	///     Start expectations for the current <typeparamref name="TStream"/> <paramref name="subject" />.
	/// </summary>
	public static IThat<TStream?> Should<TStream>(this IExpectSubject<TStream?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		where TStream : Stream
		=> new That<TStream?>(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));

	private readonly struct ValueConstraint(
		string expectation,
		Func<Stream?, bool> successIf,
		Func<Stream?, string> onFailure)
		: IValueConstraint<Stream?>
	{
		public ConstraintResult IsMetBy(Stream? actual)
		{
			if (successIf(actual))
			{
				return new ConstraintResult.Success<Stream?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), onFailure(actual));
		}

		public override string ToString()
			=> expectation;
	}
}
