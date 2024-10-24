namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class WhichNodeTests
{
	[Fact]
	public async Task WhichCreatesGoodMessage()
	{
		Dummy subject = new()
		{
			Inner = new Dummy.Nested
			{
				Id = 1
			},
			Value = "foo"
		};

		async Task Act()
			=> await Expect.That(subject).Should().Is<Dummy>()
				.Which(p => p.Value, e => e.Is("bar"));

		await Expect.That(Act).Should().Throw<XunitException>()
			.Which.HasMessage("""
			                  Expected subject to
			                  is type Dummy which Value is equal to "bar",
			                  but found "foo" which differs at index 0:
			                     ↓ (actual)
			                    "foo"
			                    "bar"
			                     ↑ (expected)
			                  at Expect.That(subject).Is<Dummy>().Should().Which(p => p.Value, e => e.Is("bar"))
			                  """);
	}

	private class Dummy
	{
		public Nested? Inner { get; set; }
		public string? Value { get; set; }

		public class Nested
		{
			public int Id { get; set; }
			#pragma warning disable CS0649
			public int Field;
			#pragma warning restore CS0649

			public int Method() => Id + 1;
		}
	}
}
