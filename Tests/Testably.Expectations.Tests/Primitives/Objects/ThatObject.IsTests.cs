using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Primitives.Objects;

public sealed partial class ThatObject
{
	public sealed class IsTests
	{
		[Theory]
		[AutoData]
		public async Task S(int value)
		{
			object sut = new Other
			{
				Value = value
			};

			var result = await Expect.That(sut).Is<Other>();
			await Expect.That(result.Value).Is(value);
		}
	}
}
