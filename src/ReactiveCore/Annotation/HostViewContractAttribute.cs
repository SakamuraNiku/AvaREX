namespace ReactiveCore.Annotation;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class HostViewContractAttribute : Attribute
{
    #region Auto Properties

    public bool ByName { get; init; }
    public string Contract { get; init; } = string.Empty;

    #endregion

    #region Constructors

    public HostViewContractAttribute() { }

    #endregion

    #region Overrides

    public override string ToString() => Contract;

    #endregion
}