using System;
using System.IO;
using Testably.Expectations.Core.Constraints;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStreamExtensions
{
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
