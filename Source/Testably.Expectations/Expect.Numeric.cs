using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Expectations;

namespace Testably.Expectations;

public static partial class Expect
{
	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.Int32 That(int subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<int>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.UInt32 That(uint subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<uint>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.Decimal That(decimal subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<decimal>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.Byte That(byte subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<byte>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.SByte That(sbyte subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<sbyte>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.Short That(short subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<short>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.UShort That(ushort subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ushort>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.Long That(long subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<long>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.ULong That(ulong subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ulong>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.Float That(float subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<float>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber.Double That(double subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<double>(subject, doNotPopulateThisValue));
}
