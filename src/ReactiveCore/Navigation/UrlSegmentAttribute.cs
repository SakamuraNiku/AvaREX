namespace ReactiveCore.Navigation;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class UrlSegmentAttribute : ValueAttribute<string>
{
    public UrlSegmentAttribute(string segment) : base(segment) { }
}