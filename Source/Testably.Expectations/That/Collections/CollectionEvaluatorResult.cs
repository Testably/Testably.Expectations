namespace Testably.Expectations.That.Collections;

/// <summary>
///     The result when checking the condition in an <see cref="ICollectionEvaluator{TItem}" />.
/// </summary>
public record struct CollectionEvaluatorResult(bool IsSuccess, string Error);
