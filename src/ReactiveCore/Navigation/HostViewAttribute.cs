namespace ReactiveCore.Navigation;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class HostViewAttribute : Attribute
{
    public bool IsStartUpView { get; set; } = false;
}