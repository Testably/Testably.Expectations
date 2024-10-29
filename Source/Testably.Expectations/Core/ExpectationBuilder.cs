using System.Text;
using System.Threading.Tasks;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Nodes;
using Testably.Expectations.Core.Sources;

namespace Testably.Expectations.Core;

internal class ExpectationBuilder<TValue> : ExpectationBuilder
{
	/// <summary>
	///     The subject.
	/// </summary>
	private readonly IValueSource<TValue> _subjectSource;


	public ExpectationBuilder(TValue subject, string subjectExpression) : base(subjectExpression)
	{
		_subjectSource = new ValueSource<TValue>(subject);
	}

	public ExpectationBuilder(IValueSource<TValue> subjectSource, string subjectExpression) : base(subjectExpression)
	{
		//_failureMessageBuilder = new FailureMessageBuilder(subjectExpression);
		_subjectSource = subjectSource;
	}

	/// <inheritdoc />
	internal override async Task<ConstraintResult> IsMet(
		EvaluationContext.EvaluationContext context, Node rootNode)
	{
		SourceValue<TValue> data = await _subjectSource.GetValue();
		return await rootNode.IsMetBy(data, context);
	}
}
