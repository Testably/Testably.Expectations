using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatDelegate
{
	public sealed class WithoutValue : ThatDelegate
	{
		internal WithoutValue(IExpectationBuilder expectationBuilder)
			: base(expectationBuilder)
		{
		}

		/// <summary>
		///     Verifies that the delegate does not throw any exception.
		/// </summary>
		public AssertionResult DoesNotThrow()
			=> new(_expectationBuilder.Add(
				new DoesNotThrowExpectation<DelegateSource.NoValue>(),
				b => b.AppendMethod(nameof(DoesNotThrow))));
	}
}
