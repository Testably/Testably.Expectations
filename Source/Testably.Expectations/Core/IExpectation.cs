namespace Testably.Expectations.Core;

public interface IExpectation
{
}

public interface IExpectation<in T> : IExpectation
{
	public ExpectationResult IsMetBy(T actual);
}

public interface IExpectation<in TActual, TTarget> : IExpectation<TActual>
{
}
