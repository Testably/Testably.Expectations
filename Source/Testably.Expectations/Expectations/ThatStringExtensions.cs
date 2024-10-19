using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static class ThatStringExtensions
{
	/// <summary>
	///     Verifies that the actual value is equal to <paramref name="expected" />.
	/// </summary>
	public static AssertionResult<string?, That<string?>> Is(this That<string?> source,
		string? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsExpectation(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the actual value is not <see langword="null" />.
	/// </summary>
	public static AssertionResult<string, That<string?>> IsNotNull(this That<string?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotNullExpectation(),
				b => b.AppendMethod(nameof(IsNotNull))),
			source);

	/// <summary>
	///     Verifies that the actual value is <see langword="null" />.
	/// </summary>
	public static AssertionResult<string?, That<string?>> IsNull(this That<string?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNullExpectation(),
				b => b.AppendMethod(nameof(IsNull))),
			source);

	private readonly struct IsExpectation : IExpectation<string?>
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

	private readonly struct IsNullExpectation : IExpectation<string?>
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

			return new ExpectationResult.Success<string?>(null, ToString());
		}

		#endregion

		/// <inheritdoc />
		public override string ToString()
			=> "is null";
	}
}
