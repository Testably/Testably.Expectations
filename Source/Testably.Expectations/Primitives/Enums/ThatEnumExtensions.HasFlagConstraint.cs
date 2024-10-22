using System;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumExtensions
{
	private readonly struct HasFlagConstraint<TEnum>(TEnum expectedFlag) : IConstraint<TEnum>
		where TEnum : struct, Enum
	{
		public ConstraintResult IsMetBy(TEnum actual)
		{
			if (actual.HasFlag(expectedFlag))
			{
				return new ConstraintResult.Success<TEnum?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> $"has flag {Formatter.Format(expectedFlag)}";
	}
}
