﻿using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Expectations;

public abstract partial class ThatDelegate
{
	public class ThrowsExceptionResult<TException> : AssertionResult<TException>
		where TException : Exception
	{
		public ThatException<TException> Which
			=> new(_expectationBuilder.Which<DelegateSource.WithoutValue, TException>(
				PropertyAccessor<DelegateSource.WithoutValue, TException?>.FromFunc(p => p.Exception as TException,
					""),
				b => b.Append(".").Append(nameof(Which)),
				" which "));

		private readonly IExpectationBuilder _expectationBuilder;

		internal ThrowsExceptionResult(IExpectationBuilder expectationBuilder) : base(
			expectationBuilder)
		{
			_expectationBuilder = expectationBuilder;
		}
	}
}
