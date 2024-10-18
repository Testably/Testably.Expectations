using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatDelegate
{
	public sealed class WithValue<TValue> : ThatDelegate
	{
		internal WithValue(IExpectationBuilder expectationBuilder)
			: base(expectationBuilder)
		{
		}

		/// <summary>
		///     Verifies that the delegate does not throw any exception.
		/// </summary>
		public AssertionResult<TValue> DoesNotThrow()
			=> new(_expectationBuilder.Add(
				new DoesNotThrowExpectation<TValue>(),
				b => b.AppendMethod(nameof(DoesNotThrow))));
	}
}
