using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Expectations.Objects;

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

			var result = await That(sut).Is<Other>();
			await That(result.Value).Is(value);
		}
	}
}
