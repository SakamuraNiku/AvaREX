namespace ReactiveCore.Navigation;

/// <summary>
/// Represents the base definition of ViewModel that can be navigated to.
/// </summary>
public interface IReactiveViewModel : IViewModel, IRoutableViewModel, IPathMember { }

/// <summary>
/// Represents the base definition of ViewModel that can be navigated to.
/// </summary>
/// <typeparam name="T">ViewModel`s data type.</typeparam>
public interface IReactiveViewModel<T> : IViewModel<T>, IRoutableViewModel where T : class { }
