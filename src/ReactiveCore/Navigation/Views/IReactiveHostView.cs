namespace ReactiveCore.Navigation;

/// <summary>
/// Represents the base definition of View that shows navigation results.
/// </summary>
/// <remarks>Implement <see cref="IReactiveHostView{T}"/> instead.</remarks>
public interface IReactiveHostView : IViewFor, IEnableLogger { }

/// <summary>
/// Represents the base definition of HostView that shows navigation results.
/// </summary>
/// <typeparam name="T">HostView`s ViewModel type.</typeparam>
public interface IReactiveHostView<T> : IReactiveHostView, IViewFor<T>
    where T : class, IReactiveHostViewModel { }
