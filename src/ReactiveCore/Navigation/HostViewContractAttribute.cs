namespace ReactiveCore.Navigation;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class HostViewContractAttribute : Attribute
{
    #region Auto Properties

    public string Contract { get; }

    #endregion

    #region Constructors

    public HostViewContractAttribute(string contract) => Contract = contract;

    #endregion
}