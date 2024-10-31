using System.Collections.Generic;
using System.Linq;

namespace Testably.Expectations.Tests.ThatTests.Exceptions;

public sealed partial class ExceptionShould
{
	public class HaveRecursiveInnerExceptionsTests
	{
		[Fact]
		public async Task WhenAllInnerExceptionsMatchTheCondition_ShouldSucceed()
		{
			Exception subject = new("outer",
				new Exception("inner1", 
					new AggregateException("inner2",
						new Exception("inner3A"),
						new Exception("inner3B"))));

			var result = Expect.That(new AggregateException().InnerExceptions).Should().All()
				.Satisfy(e => e.Message == "inner3A");
			
			async Task Act()
				=> await That(subject).Should().HaveRecursiveInnerExceptions(c => c.All().Satisfy(e => e.Message.StartsWith("inner")));

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenInnerExceptionsDoNotMatchTheCondition_ShouldFail()
		{
			Exception subject = new("outer",
				new Exception("inner1", 
					new AggregateException("inner2",
						new Exception("inner3A"),
						new Exception("inner3B"))));

			var result = Expect.That(new AggregateException().InnerExceptions).Should().All()
				.Satisfy(e => e.Message == "inner3A");
			
			async Task Act()
				=> await That(subject).Should().HaveRecursiveInnerExceptions(c => c.All().Satisfy(e => e.Message != "inner3A"));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have recursive inner exceptions which have all items satisfying "e => e.Message != "inner3A"",
				             but found not all items
				             at Expect.That(subject).Should().HaveRecursiveInnerExceptions(c => c.All().Satisfy(e => e.Message != "inner3A"))
				             """);
		}
	}
}
