using System.Collections.Generic;
using System.Linq;

namespace Testably.Expectations.Common;
internal class ConstraintBuilder<TActual> : IConstraintBuilder<TActual>
{
	private List<IConstraint> _constraints = new();
	public ExpectationResult<TActual> ApplyTo(TActual actual)
	{
		foreach (var constraint in _constraints)
		{
			var result = constraint.Satisfies(actual);
			if (!result.IsSuccess)
			{
				return new ExpectationResult<TActual>(constraint.ExpectationText, false);
			}
		}

		return new ExpectationResult<TActual>(ToString(), true);
	}

	public TConstraint Append<TConstraint>(TConstraint constraint)
		where TConstraint : IConstraint
	{
		_constraints.Add(constraint);
		return constraint;
	}

	public override string ToString()
		=> string.Join(" and ", _constraints.Select(x => x.ExpectationText));
}
