﻿namespace Testably.Expectations.That.Delegates;

internal class ThrowsOption
{
	public bool DoCheckThrow { get; private set; } = true;

	public void CheckThrow(bool doCheckThrow)
	{
		DoCheckThrow = doCheckThrow;
	}
}