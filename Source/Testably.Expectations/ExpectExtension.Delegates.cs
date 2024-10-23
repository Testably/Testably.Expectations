using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations;

public static partial class ExpectExtension
{
	/// <summary>
	///     Start expectations for the current <see cref="Action" /> <paramref name="subject" />.
	/// </summary>
	public static ThatDelegate.WithoutValue Should(this IExpectThat<ThatDelegate.WithoutValue> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatDelegate.WithoutValue(subject.ExpectationBuilder);
	}

	/// <summary>
	///     Start expectations for the current <see cref="Func{TValue}" /> <paramref name="subject" />.
	/// </summary>
	public static ThatDelegate.WithValue<TValue> Should<TValue>(this IExpectThat<ThatDelegate.WithValue<TValue>> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatDelegate.WithValue<TValue>(subject.ExpectationBuilder);
	}
}
