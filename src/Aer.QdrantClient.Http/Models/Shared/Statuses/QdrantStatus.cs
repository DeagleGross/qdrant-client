// ReSharper disable MemberCanBeInternal
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Aer.QdrantClient.Http.Models.Shared;

/// <summary>
/// Represents the qdrant operation status.
/// </summary>
public class QdrantStatus
{
    /// <summary>
    /// The sqdrant status type.
    /// </summary>
    public QdrantOperationStatusType Type { get; }

    /// <summary>
    /// <c>true</c> if status indicates success, <c>false</c> otherwise.
    /// </summary>
    public bool IsSuccess => Type == QdrantOperationStatusType.Ok;

    /// <summary>
    /// Gets the qdrant operation error. This property has a value only if an error occurred.
    /// </summary>
    public string Error { get; init; }

    /// <summary>
    /// Gets the raw operation status string. This property has a value only in case of an unknown status.
    /// </summary>
    public string RawStatusString { get; init; }

    /// <summary>
    /// The exeption that happened during qdrant operation execution.
    /// </summary>
    public Exception Exception { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QdrantStatus"/> class.
    /// </summary>
    /// <param name="type">The qdrant operation status.</param>
    public QdrantStatus(QdrantOperationStatusType type)
    {
        Type = type;
    }

    /// <summary>
    /// Tries to get error message from this qudrant status. If the status is <c>Ok</c> returns <c>null</c>.
    /// </summary>
    public string GetErrorMessage() => Error ?? RawStatusString;

    /// <summary>
    /// Returns a string representation of the Qdrant status.
    /// </summary>
    public override string ToString()
        => $"[{Type}]; IsSuccess: '{IsSuccess}'; Error: '{GetErrorMessage() ?? "NONE"}'; Exception: {Exception?.ToString() ?? "NONE"}";
}
