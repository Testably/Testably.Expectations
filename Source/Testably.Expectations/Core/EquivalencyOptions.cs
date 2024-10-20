using System.Collections.Generic;
using System.Linq;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Core;

/// <summary>
///     Options for equivalency.
/// </summary>
public class EquivalencyOptions
{
	internal IReadOnlyList<string> MembersToIgnore => _membersToIgnore;
	private readonly List<string> _membersToIgnore = new();

	/// <summary>
	///     Ignores the <paramref name="memberToIgnore" /> when checking for equivalency.
	/// </summary>
	public EquivalencyOptions IgnoringMember(string memberToIgnore)
	{
		_membersToIgnore.Add(memberToIgnore);
		return this;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		if (_membersToIgnore.Any())
		{
			return
				$" ignoring [{string.Join(", ", _membersToIgnore.Select(m => Formatter.Format(m)))}]";
		}

		return "";
	}
}
