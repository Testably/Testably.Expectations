using System.Collections.Generic;

namespace Testably.Expectations.Tests.ThatTests.Strings;

public sealed partial class StringShould
{
	private static readonly string StringWith100Characters =
		"Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut l";

	private static readonly string StringWithMoreThan100Characters =
		"Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore";

	/// <summary>
	///     A test <see cref="IEqualityComparer{T}" /> for <see langword="string" />s that
	///     ignores case differences only in vocals.
	/// </summary>
	public sealed class IgnoreCaseForVocalsComparer : IEqualityComparer<string>
	{
		#region IEqualityComparer<string> Members

		public bool Equals(string? x, string? y)
		{
			string? adjustedX = LowercaseVocals(x);
			string? adjustedY = LowercaseVocals(y);

			return adjustedX?.Equals(adjustedY, StringComparison.Ordinal) == true;
		}

		public int GetHashCode(string obj)
		{
			return obj.GetHashCode();
		}

		#endregion

		private static string? LowercaseVocals(string? input)
			=> input?.Replace('A', 'a')
				.Replace('E', 'e')
				.Replace('I', 'i')
				.Replace('O', 'o')
				.Replace('U', 'u');
	}
}
