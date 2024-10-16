using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.CoreVoid.Helpers;
using Testably.Expectations.Expectations.Booleans;

namespace Testably.Expectations.Expectations;

public class BooleanExpectations
{
	private readonly IExpectationBuilder _expectationBuilder;

	internal BooleanExpectations(IExpectationBuilder expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Asserts that the value implies the specified <paramref name="consequent" /> value..
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> Implies(bool consequent,
		[CallerArgumentExpression("consequent")]
		string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new Implies(consequent),
				b => b.AppendMethod(nameof(Implies), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Asserts that the value is equal to the specified <paramref name="expected" /> value.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> Is(bool expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new Is(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Asserts that the value is <see langword="false" />.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> IsFalse()
		=> new(_expectationBuilder.Add(
				new Is(false),
				b => b.AppendMethod(nameof(IsFalse))),
			this);

	/// <summary>
	///     Asserts that the value is not equal to the specified <paramref name="unexpected" /> value.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> IsNot(bool unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.Add(
				new IsNot(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			this);

	/// <summary>
	///     Asserts that the value is <see langword="true" />.
	/// </summary>
	public AssertionResult<bool, BooleanExpectations> IsTrue()
		=> new(_expectationBuilder.Add(
				new Is(true),
				b => b.AppendMethod(nameof(IsTrue))),
			this);

	public class Nullable
	{
		private readonly IExpectationBuilder _expectationBuilder;

		internal Nullable(IExpectationBuilder expectationBuilder)
		{
			_expectationBuilder = expectationBuilder;
		}

		/// <summary>
		///     Asserts that the value is equal to the specified <paramref name="expected" /> value.
		/// </summary>
		public AssertionResult<bool?, Nullable> Is(bool? expected,
			[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
			=> new(_expectationBuilder.Add(
					new NullableIs(expected),
					b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
				this);

		/// <summary>
		///     Asserts that the value is <see langword="false" />.
		/// </summary>
		public AssertionResult<bool?, Nullable> IsFalse()
			=> new(_expectationBuilder.Add(
					new NullableIs(false),
					b => b.AppendMethod(nameof(IsFalse))),
				this);

		/// <summary>
		///     Asserts that the value is not equal to the specified <paramref name="unexpected" /> value.
		/// </summary>
		public AssertionResult<bool?, Nullable> IsNot(bool? unexpected,
			[CallerArgumentExpression("unexpected")]
			string doNotPopulateThisValue = "")
			=> new(_expectationBuilder.Add(
					new NullableIsNot(unexpected),
					b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
				this);

		/// <summary>
		///     Asserts that the value is not <see langword="false" />.
		/// </summary>
		public AssertionResult<bool?, Nullable> IsNotFalse()
			=> new(_expectationBuilder.Add(
					new NullableIsNot(false),
					b => b.AppendMethod(nameof(IsNotFalse))),
				this);

		/// <summary>
		///     Asserts that the value is not <see langword="null" />.
		/// </summary>
		public AssertionResult<bool?, Nullable> IsNotNull()
			=> new(_expectationBuilder.Add(
					new NullableIsNot(null),
					b => b.AppendMethod(nameof(IsNotNull))),
				this);

		/// <summary>
		///     Asserts that the value is not <see langword="true" />.
		/// </summary>
		public AssertionResult<bool?, Nullable> IsNotTrue()
			=> new(_expectationBuilder.Add(
					new NullableIsNot(true),
					b => b.AppendMethod(nameof(IsNotTrue))),
				this);

		/// <summary>
		///     Asserts that the value is <see langword="null" />.
		/// </summary>
		public AssertionResult<bool?, Nullable> IsNull()
			=> new(_expectationBuilder.Add(
					new NullableIs(null),
					b => b.AppendMethod(nameof(IsNull))),
				this);

		/// <summary>
		///     Asserts that the value is <see langword="true" />.
		/// </summary>
		public AssertionResult<bool?, Nullable> IsTrue()
			=> new(_expectationBuilder.Add(
					new NullableIs(true),
					b => b.AppendMethod(nameof(IsTrue))),
				this);
	}
}
