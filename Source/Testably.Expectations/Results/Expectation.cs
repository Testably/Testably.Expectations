using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation without an underlying value.
/// </summary>
[StackTraceHidden]
public abstract class Expectation
{
	internal abstract Task<ConstraintResult> GetResult();

	internal abstract string GetSubject();

	public class All : Expectation
	{
		private readonly Expectation[] _expectations;

		internal All(Expectation[] expectations)
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
		internal override async Task<ConstraintResult> GetResult()
		{
			Dictionary<int, string> expectationTexts = new();
			Dictionary<int, string>? failureTexts = new();
			int index = 0;
			foreach (Expectation? expectation in _expectations)
			{
				index++;
				ConstraintResult? result = await expectation.GetResult();
				expectationTexts.Add(index,
					$"Expected {expectation.GetSubject()} to {result.ExpectationText}");
				if (result is ConstraintResult.Failure failure)
				{
					failureTexts.Add(index, failure.ResultText);
				}
			}

			string expectationText = string.Join(Environment.NewLine, expectationTexts
				.Select(expectation
					=> $" [{expectation.Key:00}] {expectation.Value.Indent("      ", indentFirstLine: false)}"));

			if (failureTexts.Count > 0)
			{
				return new ConstraintResult.Failure(expectationText, string.Join(
					Environment.NewLine, failureTexts
						.Select(failure
							=> $" [{failure.Key:00}] {failure.Value.Indent("      ", indentFirstLine: false)}")));
			}

			return new ConstraintResult.Success(expectationText);
		}

		/// <inheritdoc />
		internal override string GetSubject()
			=> "";

		private string CreateFailureMessage(ConstraintResult.Failure failure)
		{
			return $"""
			        Expected all of the following to succeed:
			        {failure.ExpectationText}
			        but
			        {failure.ResultText}
			        """;
		}

		private async Task GetResultOrThrow()
		{
			ConstraintResult result = await GetResult();

			if (result is ConstraintResult.Failure failure)
			{
				Fail.Test(CreateFailureMessage(failure));
			}
		}
	}

	public class Any : Expectation
	{
		private readonly Expectation[] _expectations;

		internal Any(Expectation[] expectations)
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
		internal override async Task<ConstraintResult> GetResult()
		{
			Dictionary<int, string> expectationTexts = new();
			Dictionary<int, string>? failureTexts = new();
			int index = 0;
			foreach (Expectation? expectation in _expectations)
			{
				index++;
				ConstraintResult? result = await expectation.GetResult();
				expectationTexts.Add(index,
					$"Expected {expectation.GetSubject()} to {result.ExpectationText}");
				if (result is ConstraintResult.Failure failure)
				{
					failureTexts.Add(index, failure.ResultText);
				}
			}

			string expectationText = string.Join(Environment.NewLine, expectationTexts
				.Select(expectation
					=> $" [{expectation.Key:00}] {expectation.Value.Indent("      ", indentFirstLine: false)}"));

			if (failureTexts.Count == expectationTexts.Count)
			{
				return new ConstraintResult.Failure(expectationText, string.Join(
					Environment.NewLine, failureTexts
						.Select(failure
							=> $" [{failure.Key:00}] {failure.Value.Indent("      ", indentFirstLine: false)}")));
			}

			return new ConstraintResult.Success(expectationText);
		}

		/// <inheritdoc />
		internal override string GetSubject()
			=> "";

		private string CreateFailureMessage(ConstraintResult.Failure failure)
		{
			return $"""
			        Expected any of the following to succeed:
			        {failure.ExpectationText}
			        but
			        {failure.ResultText}
			        """;
		}

		private async Task GetResultOrThrow()
		{
			ConstraintResult result = await GetResult();

			if (result is ConstraintResult.Failure failure)
			{
				Fail.Test(CreateFailureMessage(failure));
			}
		}
	}
}
