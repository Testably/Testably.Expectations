namespace Testably.Expectations.Core.Formatting;

/// <summary>
///     Formatting options used in the <see cref="Formatter.Format{T}(T, FormattingOptions)" /> method.
/// </summary>
public class FormattingOptions
{
	/// <summary>
	///     Format the objects on multiple lines.
	/// </summary>
	public static FormattingOptions Default { get; } = new(true);

	/// <summary>
	///     Format the objects on a single line.
	/// </summary>
	public static FormattingOptions SingleLine { get; } = new(false);

	internal bool UseLineBreaks { get; }

	private FormattingOptions(bool useLineBreaks)
	{
		UseLineBreaks = useLineBreaks;
	}
}
