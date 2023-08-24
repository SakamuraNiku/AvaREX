namespace ReactiveCore.Navigation;

public static class NavigationExtensions
{
    public static string? GetUrlSegment(this IPathMember vm) =>
        vm.GetAttribute<UrlSegmentAttribute>()?.Segment;

    public static string? GetHostViewContract(this IReactiveViewModel vm)
    {
        var attr = vm.GetAttribute<HostViewContractAttribute>();
        if (attr == null) return null!;

        if (attr.ByName) return vm.GetType().Name.Replace("Model", null);

        return attr.Contract;
    }
}