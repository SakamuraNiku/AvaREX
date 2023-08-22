namespace ReactiveCore;

public static class NavigationExtensions
{
    public static string? GetUrlSegment(this IReactiveViewModel vm) =>
        vm.GetValue<UrlSegmentAttribute, string>();
}