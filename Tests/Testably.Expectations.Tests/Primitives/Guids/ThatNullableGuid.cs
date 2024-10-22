﻿namespace Testably.Expectations.Tests.Primitives.Guids;

public sealed partial class ThatNullableGuid
{
	/// <summary>
	///     Use a fixed random <see cref="Guid"/> in each test run to ensure, that the tests don't rely on special times.
	/// </summary>
	private static readonly Lazy<Guid> FixedGuidLazy = new(Guid.NewGuid);

	private static Guid? FixedGuid()
		=> FixedGuidLazy.Value;
	private static Guid? OtherGuid()
		=> Guid.NewGuid();
}
