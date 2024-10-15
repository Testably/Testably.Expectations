using System;
using System.Threading.Tasks;
using TUnit.Assertions.Core;
using TUnit.Assertions.Core.Internal;

namespace TUnit.Assertions.Assertions.Delegates;

public abstract class DelegateAssertions
{
	public class WithValue<TValue> : DelegateAssertions
	{
		private readonly AssertionBuilder _assertionBuilder;
		private readonly Func<Task<TValue>> _delegate;
		private TValue? _value;

		internal WithValue(AssertionBuilder assertionBuilder, Func<Task<TValue>> @delegate)
			: base(assertionBuilder)
		{
			_assertionBuilder = assertionBuilder;
			_delegate = @delegate;
		}

		public AssertionResult<TValue> DoesNotThrow()
		{
			return new AssertionResult<TValue>(_assertionBuilder, async () =>
			{
				await Evaluate();
				return _value!;
			});
		}

		protected override async Task<Exception?> Evaluate()
		{
			try
			{
				_value = await _delegate.Invoke();
			}
			catch (Exception ex)
			{
				return ex;
			}

			return null;
		}
	}
	public class WithoutValue : DelegateAssertions
	{
		private readonly AssertionBuilder _assertionBuilder;
		private readonly Func<Task> _delegate;

		internal WithoutValue(AssertionBuilder assertionBuilder, Func<Task> @delegate)
			: base(assertionBuilder)
		{
			_assertionBuilder = assertionBuilder;
			_delegate = @delegate;
		}

		public AssertionResult DoesNotThrow()
		{
			return new AssertionResult(_assertionBuilder);
		}

		protected override async Task<Exception?> Evaluate()
		{
			try
			{
				await _delegate.Invoke();
			}
			catch (Exception ex)
			{
				return ex;
			}

			return null;
		}
	}

	protected abstract Task<Exception?> Evaluate();

	internal DelegateAssertions(AssertionBuilder assertionBuilder)
	{
	}

	public DelegateAssertionResult<Exception> ThrowsException()
	{
		return null!;//new AssertionResult<Exception, DelegateAssertions>(_value, this);
	}

	public DelegateAssertionResult<TException> Throws<TException>()
	where TException : Exception
	{
		return null!;//new AssertionResult<Exception, DelegateAssertions>(_value, this);
	}

	public DelegateAssertionResult<TException> ThrowsExactly<TException>()
		where TException : Exception
	{
		return null!;//new AssertionResult<Exception, DelegateAssertions>(_value, this);
	}
}
