using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Results;

/// <summary>
///     Base class for expectation results.
/// </summary>
/// <remarks>
///     Create instances by using the static methods on the <see cref="Expect" /> class.
/// </remarks>
[StackTraceHidden]
public abstract class Expectation
{
	internal abstract Task<Result> GetResult(int index);

	internal struct Result(int index, string subjectLine, ConstraintResult result)
	{
		public int Index { get; } = index;
		public string SubjectLine { get; } = subjectLine;
		public ConstraintResult ConstraintResult { get; } = result;
	}

	/// <summary>
	///     Combination of multiple expectations.
	/// </summary>
	public abstract class Combination : Expectation
	{
		private readonly Expectation[] _expectations;

		internal Combination(Expectation[] expectations)
		{
			if (expectations.Length == 0)
			{
				throw new ArgumentException("You must provide at least one expectation.",
					paramName: nameof(expectations));
			}

			_expectations = expectations;
		}

		/// <summary>
		///     By awaiting the result, the expectations are verified.
		///     <para />
		///     Will throw an exception, when the expectations are not met.
		/// </summary>
		public TaskAwaiter GetAwaiter()
		{
			Task result = GetResultOrThrow();
			return result.GetAwaiter();
		}

		/// <inheritdoc />
		internal override async Task<Result> GetResult(int index)
		{
			List<string> expectationTexts = new();
			List<string>? failureTexts = new();
			foreach (Expectation? expectation in _expectations)
			{
				Result result = await expectation.GetResult(index);
				index = result.Index;
				if (expectation is Combination)
				{
					expectationTexts.Add(
						$"{result.SubjectLine}{Environment.NewLine}{result.ConstraintResult.ExpectationText
						}".Indent());
				}
				else
				{
					expectationTexts.Add(
						$"{result.SubjectLine} {result.ConstraintResult.ExpectationText
							.Indent("      ", indentFirstLine: false)}");
				}

				if (result.ConstraintResult is ConstraintResult.Failure failure)
				{
					string failureText;
					if (expectation is Combination)
					{
						failureText =
							$"{failure.ResultText.Indent()}";
					}
					else
					{
						failureText =
							$" [{index:00}] {failure.ResultText.Indent("      ", indentFirstLine: false)}";
					}

					failureTexts.Add(failureText);
				}
			}

			string expectationText = string.Join(Environment.NewLine, expectationTexts);

			if (!IsSuccess(failureTexts.Count, expectationTexts.Count))
			{
				ConstraintResult.Failure? result = new(expectationText,
					string.Join(
						Environment.NewLine, failureTexts));
				return new Result(index, GetSubjectLine(), result);
			}

			return new Result(index, GetSubjectLine(),
				new ConstraintResult.Success(expectationText));
		}

		/// <summary>
		///     Returns the subject line of the <see cref="Expectation.Combination" />.
		/// </summary>
		internal abstract string GetSubjectLine();

		/// <summary>
		///     Specifies, if the combination should be treated as
		///     <see cref="ConstraintResult.Success" /> or <see cref="ConstraintResult.Failure" />
		/// </summary>
		internal abstract bool IsSuccess(int failureCount, int totalCount);

		private string CreateFailureMessage(ConstraintResult.Failure failure)
		{
			return $"""
			        {GetSubjectLine()}
			        {failure.ExpectationText}
			        but
			        {failure.ResultText}
			        """;
		}

		private async Task GetResultOrThrow()
		{
			Result result = await GetResult(0);
			if (result.ConstraintResult is ConstraintResult.Failure failure)
			{
				Fail.Test(CreateFailureMessage(failure));
			}
		}

		/// <summary>
		///     All <paramref name="expectations" /> must be met.
		/// </summary>
		public class All(Expectation[] expectations) : Combination(expectations)
		{
			/// <inheritdoc />
			internal override string GetSubjectLine()
				=> "Expected all of the following to succeed:";

			/// <inheritdoc />
			internal override bool IsSuccess(int failureCount, int totalCount)
				=> failureCount == 0;
		}

		/// <summary>
		///     Any of the <paramref name="expectations" /> must be met.
		/// </summary>
		public class Any(Expectation[] expectations) : Combination(expectations)
		{
			/// <inheritdoc />
			internal override string GetSubjectLine()
				=> "Expected any of the following to succeed:";

			/// <inheritdoc />
			internal override bool IsSuccess(int failureCount, int totalCount)
				=> failureCount < totalCount;
		}
	}
}
