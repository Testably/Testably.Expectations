using System;
using System.ComponentModel;

namespace Testably.Expectations.Common;

public interface IConstraint
{
	string ExpectationText { get; }
	ConstraintResult Satisfies(object? actual);
}

public interface IConstraint<TActual> : IConstraint
{
}
public interface IConstraint<TActual, TTarget> : IConstraint<TTarget>
{
}
