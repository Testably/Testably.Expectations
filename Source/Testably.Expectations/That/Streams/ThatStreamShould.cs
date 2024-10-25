using System;
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
	public static That<TStream?> Should<TStream>(this IExpectThat<TStream?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		where TStream : Stream
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new That<TStream?>(subject.ExpectationBuilder);
	}

	private readonly struct Constraint(
		string expectation,
		Func<Stream?, bool> successIf,
		Func<Stream?, string> onFailure)
		: IConstraint<Stream?>
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
