using Testably.Expectations.Constraints;

namespace Testably.Expectations.Core;

public interface IConstraint
{
	string ExpectationText { get; }
}

public interface IConstraint<in TActual> : IConstraint
{
	ConstraintResult Satisfies(TActual? actual);
}

public interface IConstraint<in TActual, TTarget> : IConstraint<TActual>
{
}
