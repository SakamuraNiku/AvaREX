namespace ReactiveCore.Attribution;

/// <summary>
/// Represents attribute that sets URL segment of a ViewModel.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class UrlSegmentAttribute : Attribute
{
    #region Auto Properties

    /// <summary>
    /// Gets ViewModel`s URL segment.
    /// </summary>
    public string Segment { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="UrlSegmentAttribute"/> class.
    /// </summary>
    /// <param name="segment">ViewModel`s URL segment.</param>
    public UrlSegmentAttribute(string segment) =>
        Segment = EscapeSegment(segment);

    #endregion

    #region Private Methods

    private static string EscapeSegment(string segment)
    {
        segment = segment.Trim();
        if (!char.IsLetter(segment[0]))
            segment = segment[1..];

        if (!char.IsLetter(segment.Last()))
            segment = segment[..1];

        return segment
            .Replace(' ', '_')
            .Replace("-", "_")
            .Replace('\\', '/')
            .Replace("/", null);
    }

    #endregion

    #region Overrides

    public override string ToString() => $"/{Segment}";

    #endregion
}