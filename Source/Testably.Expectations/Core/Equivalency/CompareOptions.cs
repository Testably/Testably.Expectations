namespace Testably.Expectations.Core.Equivalency;

internal record CompareOptions
{
    public string[] MembersToIgnore { get; set; } = [];
}
