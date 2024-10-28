#if NET6_0_OR_GREATER
using System;
using System.IO;
using Testably.Expectations.Core.Constraints;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="BufferedStream" /> values.
/// </summary>
public static partial class ThatBufferedStreamShould
{
	private readonly struct ValueConstraint(
		string expectation,
		Func<BufferedStream?, bool> successIf,
		Func<BufferedStream?, string> onFailure)
		: IValueConstraint<BufferedStream?>
	{
		public ConstraintResult IsMetBy(BufferedStream? actual)
		{
			if (successIf(actual))
			{
				return new ConstraintResult.Success<BufferedStream?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), onFailure(actual));
		}

		public override string ToString()
			=> expectation;
	}
}
#endif
