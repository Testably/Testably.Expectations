using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations;

public class ThatNumber
{
	public class Int32 : ThatNumber<int, Int32>
	{
		internal Int32(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}

	public class UInt32 : ThatNumber<uint, UInt32>
	{
		internal UInt32(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}

	public class Byte : ThatNumber<byte, Byte>
	{
		internal Byte(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}

	public class SByte : ThatNumber<sbyte, SByte>
	{
		internal SByte(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}

	public class Short : ThatNumber<short, Short>
	{
		internal Short(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}

	public class UShort : ThatNumber<ushort, UShort>
	{
		internal UShort(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}

	public class Long : ThatNumber<long, Long>
	{
		internal Long(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}

	public class ULong : ThatNumber<ulong, ULong>
	{
		internal ULong(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}

	public class Float : ThatNumber<float, Float>
	{
		private readonly IExpectationBuilder _expectationBuilder;

		internal Float(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
			_expectationBuilder = expectationBuilder;
		}

		/// <summary>
		///     Verifies that the value is seen as not a number (NaN).
		/// </summary>
		public AssertionResult<float, Float> IsNaN()
			=> new(_expectationBuilder.Add(new IsNaNExpectation<float>(float.IsNaN),
					b => b.AppendMethod(nameof(IsNaN))),
				this);
	}

	public class Double : ThatNumber<double, Double>
	{
		private readonly IExpectationBuilder _expectationBuilder;

		internal Double(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
			_expectationBuilder = expectationBuilder;
		}

		/// <summary>
		///     Verifies that the value is seen as not a number (NaN).
		/// </summary>
		public AssertionResult<double, Double> IsNaN()
			=> new(_expectationBuilder.Add(new IsNaNExpectation<double>(double.IsNaN),
					b => b.AppendMethod(nameof(IsNaN))),
				this);
	}

	public class Decimal : ThatNumber<decimal, Decimal>
	{
		internal Decimal(IExpectationBuilder expectationBuilder) : base(expectationBuilder)
		{
		}
	}
}
