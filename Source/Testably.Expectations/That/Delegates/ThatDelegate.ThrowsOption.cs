// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public abstract partial class ThatDelegate
{
	internal class ThrowsOption
	{
		public bool DoCheckThrow { get; private set; } = true;

		public void CheckThrow(bool doCheckThrow)
		{
			DoCheckThrow = doCheckThrow;
		}
	}
}
