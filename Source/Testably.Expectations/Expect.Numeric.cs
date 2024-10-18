using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Expectations;

namespace Testably.Expectations;

public static partial class Expect
{
	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<int> That(int subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<int>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<uint> That(uint subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<uint>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<decimal> That(decimal subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<decimal>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<byte> That(byte subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<byte>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<sbyte> That(sbyte subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<sbyte>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<short> That(short subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<short>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<ushort> That(ushort subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ushort>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<long> That(long subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<long>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<ulong> That(ulong subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<ulong>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<float> That(float subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<float>(subject, doNotPopulateThisValue));

	/// <summary>
	///     Start asserting the current <see cref="int" /> <paramref name="subject" />.
	/// </summary>
	public static ThatNumber<double> That(double subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<double>(subject, doNotPopulateThisValue));
}
