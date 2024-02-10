using Testably.Expectations.Core.ExpectationBuilders;

namespace Testably.Expectations.Core;

/// <summary>
///     Expect the actual value to...
/// </summary>
public class ExpectationShould
{
	private readonly IExpectationBuilderStart _expectationBuilder;

	internal ExpectationShould(IExpectationBuilderStart expectationBuilder)
	{
		_expectationBuilder = expectationBuilder;
	}

	/// <summary>
	///     Expect the actual value to be...
	/// </summary>
	public ShouldBe Be => new(_expectationBuilder);

	/// <summary>
	///     Expect the actual value to end...
	/// </summary>
	public ShouldEnd End => new(_expectationBuilder);

	/// <summary>
	///     Expect the actual value to start...
	/// </summary>
	public ShouldStart Start => new(_expectationBuilder);

	/// <summary>
	///     Expect the actual value to throw...
	/// </summary>
	public ShouldThrow Throw => new(_expectationBuilder);
}
