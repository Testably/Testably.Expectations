using System;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.CoreVoid.Helpers;
using Testably.Expectations.Expectations.Exceptions;
using Testably.Expectations.Expectations.Strings;

namespace Testably.Expectations.Expectations;

public abstract class DelegateExpectations
{
	private readonly IExpectationBuilder _expectationBuilder;

	public class WithValue<TValue> : DelegateExpectations
	{
		internal WithValue(IExpectationBuilder expectationBuilder)
			: base(expectationBuilder)
		{
		}

		public AssertionResult<TValue> DoesNotThrow()
		=> new(_expectationBuilder.Add(
			new DoesNotThrow<TValue>(),
			b => b.AppendMethod(nameof(DoesNotThrow))));
	}

	public class WithoutValue : DelegateExpectations
	{
		internal WithoutValue(IExpectationBuilder expectationBuilder)
			: base(expectationBuilder)
		{
		}

		public AssertionResult DoesNotThrow()
		=> new(_expectationBuilder.Add(
			new DoesNotThrow<object?>(),
			b => b.AppendMethod(nameof(DoesNotThrow))));
	}

	internal DelegateExpectations(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	public ExceptionAssertionResult<Exception> ThrowsException()
	=> new(_expectationBuilder.Add(
		new Throws<Exception>(),
		b => b.AppendMethod(nameof(ThrowsException))));

	public ExceptionAssertionResult<TException> Throws<TException>()
	  where TException : Exception
	=> new(_expectationBuilder.Add(
		new Throws<TException>(),
		b => b.AppendMethod(nameof(ThrowsException))));

	//public DelegateAssertionResult<Exception> ThrowsException()
	//{
	//	return null!;//new AssertionResult<Exception, DelegateAssertions>(_value, this);
	//}

	//public DelegateAssertionResult<TException> Throws<TException>()
	//where TException : Exception
	//{
	//	return null!;//new AssertionResult<Exception, DelegateAssertions>(_value, this);
	//}

	//public DelegateAssertionResult<TException> ThrowsExactly<TException>()
	//	where TException : Exception
	//{
	//	return null!;//new AssertionResult<Exception, DelegateAssertions>(_value, this);
	//}
}
