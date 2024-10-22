#if NET6_0_OR_GREATER
using System.IO;

namespace Testably.Expectations.Tests.That.Streams;

public sealed partial class ThatBufferedStream
{
	public static BufferedStream GetBufferedStream(int bufferSize)
		=> new(new MemoryStream(), bufferSize);
}
#endif
