namespace ReactiveCore.Navigation;

/// <summary>
/// Represents the base definition of View that support Routing and Binding.
/// </summary>
/// <remarks>Implement <see cref="IReactiveView{T}"/> instead.</remarks>
public interface IReactiveView : IViewFor, IEnableLogger { }

/// <summary>
/// Represents the base definition of View that support Routing and Binding.
/// </summary>
/// <typeparam name="T">View`s ViewModel type.</typeparam>
public interface IReactiveView<T> : IReactiveView, IViewFor<T>
    where T : class, IReactiveViewModel { }
