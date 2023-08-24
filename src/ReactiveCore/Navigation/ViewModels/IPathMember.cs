namespace ReactiveCore.Navigation;

/// <summary>
/// Represents base definition of object that can be part of path-based navigation tree.
/// </summary>
/// <remarks>For internal use only. Do not implement this interface.</remarks>
public interface IPathMember
{
    /// <summary>
    /// Gets a string token representing the current ViewModel.
    /// </summary>
    string? UrlPathSegment { get; }
}