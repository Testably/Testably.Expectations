using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUnit.Assertions.Core.Internal;
internal class AssertionBuilder
{
	public string Subject { get; }

	private AssertionBuilder(string subject)
	{
		Subject = subject;
	}
	public static AssertionBuilder FromSubject(string subject)
	{
		return new AssertionBuilder(subject);
	}
}
