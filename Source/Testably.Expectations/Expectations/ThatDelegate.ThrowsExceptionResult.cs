using System;
using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatDelegate
{
	public class ThrowsExceptionResult<TException> : AssertionResult<TException>
		where TException : Exception
	{
		public That<TException?> Which
			=> new(_expectationBuilder.Which<TException?, TException?>(
				PropertyAccessor<TException?, TException?>.FromFunc(p =>p.Value, ""),
				b => b.Append(".").Append(nameof(Which)), ""));

		private readonly IExpectationBuilder _expectationBuilder;

		internal ThrowsExceptionResult(IExpectationBuilder expectationBuilder) : base(
			expectationBuilder)
		{
			_expectationBuilder = expectationBuilder;
		}
	}
}
