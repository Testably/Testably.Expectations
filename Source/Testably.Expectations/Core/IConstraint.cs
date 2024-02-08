namespace Testably.Expectations.Core;

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
