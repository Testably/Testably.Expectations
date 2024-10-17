using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations;

public sealed partial class ThatString
{
	private readonly struct IsExpectation : INullableExpectation<string?>
	{
		private readonly string? _expected;

		public IsExpectation(string? expected)
		{
			_expected = expected;
		}

		#region INullableExpectation<string?> Members

		/// <inheritdoc />
		public ExpectationResult IsMetBy(string? actual)
		{
			if (actual is null && _expected is null)
			{
				return new ExpectationResult.Success(ToString());
			}

			if (_expected?.Equals(actual) == true)
			{
				return new ExpectationResult.Success<string?>(actual, ToString());
			}

			return new ExpectationResult.Failure(ToString(),
				$"found {Formatter.Format(actual)}");
		}

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> $"is equal to {Formatter.Format(_expected)}";
	}

	private readonly struct IsNotNullExpectation : IExpectation<string>
	{
		#region IExpectation<string> Members

		/// <inheritdoc />
		public ExpectationResult IsMetBy(string? actual)
		{
			if (actual is null)
			{
				return new ExpectationResult.Failure(ToString(), "it was");
			}

			return new ExpectationResult.Success<string>(actual, ToString());
		}

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> "is not null";
	}

	private readonly struct IsNullExpectation : IExpectation<string>
	{
		#region IExpectation<string> Members

		/// <inheritdoc />
		public ExpectationResult IsMetBy(string? actual)
		{
			if (actual is not null)
			{
				return new ExpectationResult.Failure(ToString(),
					$"found {Formatter.Format(actual)}");
			}

			return new ExpectationResult.Success<string?>(actual, ToString());
		}

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> "is null";
	}
}
