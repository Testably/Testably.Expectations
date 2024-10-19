namespace Testably.Expectations.Core.Formatting;

public class FormattingOptions
{
	public static FormattingOptions SingleLine { get; } = new()
	{
		UseLineBreaks = false
	};

	public static FormattingOptions Default { get; } = new()
	{
		UseLineBreaks = true
	};

	public bool UseLineBreaks { get; set; }
}
