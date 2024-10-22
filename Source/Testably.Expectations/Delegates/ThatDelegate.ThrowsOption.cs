// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on delegate values.
/// </summary>
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
