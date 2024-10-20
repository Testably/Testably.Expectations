using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Results;

namespace Testably.Expectations.Expectations;

/// <summary>
///     Expectations on delegates.
/// </summary>
public abstract partial class ThatDelegate
{
	/// <summary>
	///     An <see cref="ExpectationResult" /> when an exception was thrown.
	/// </summary>
	/// <typeparam name="TException"></typeparam>
	public class ThrowsExceptionResult<TException> : ExpectationResult<TException, ThrowsExceptionResult<TException>>
		where TException : Exception
	{
		/// <summary>
		///     Additional expectations on the thrown <typeparamref name="TException" />.
		/// </summary>
		public That<TException?> Which
			=> new(_expectationBuilder.Which<TException?, TException?>(
				PropertyAccessor<TException?, TException?>.FromFunc(p => p.Value, ""),
				null,
				b => b.Append(".").Append(nameof(Which)),
				whichTextSeparator: ""));

		private readonly IExpectationBuilder _expectationBuilder;

		internal ThrowsExceptionResult(IExpectationBuilder expectationBuilder) : base(
			expectationBuilder)
		{
			_expectationBuilder = expectationBuilder;
		}
	}
}
