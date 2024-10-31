namespace Testably.Expectations.That.Collections;

/// <summary>
///     The result when checking the condition in an <see cref="ICollectionEvaluator{TItem}" />.
/// </summary>
/// <param name="IsSuccess"></param>
/// <param name="Error"></param>
public record struct CollectionEvaluatorResult(bool IsSuccess, string Error);
