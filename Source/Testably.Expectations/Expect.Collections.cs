using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class Expect
{
	/// <summary>
	///     Start delegate assertions on the current <see cref="string" /> values.
	/// </summary>
	public static That<IEnumerable<string>> That(IEnumerable<string> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new(new ExpectationBuilder<IEnumerable<string>>(subject, doNotPopulateThisValue));

}
