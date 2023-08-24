namespace ReactiveCore.Navigation;

/// <summary>
/// Represents the base definition of HostView`s ViewModel.
/// </summary>
public interface IReactiveHostViewModel : IViewModel, IPathMember, IScreen { }


/// <summary>
/// Represents the base definition of HostView`s ViewModel.
/// </summary>
/// <typeparam name="T">ViewModel`s data type.</typeparam>
public interface IReactiveHostViewModel<T> : IReactiveHostViewModel, IViewModel<T> where T : class { }
