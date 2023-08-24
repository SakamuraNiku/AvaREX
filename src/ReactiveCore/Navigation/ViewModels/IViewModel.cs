namespace ReactiveCore.Navigation;

/// <summary>
/// Represents the base definition of ViewModel.
/// </summary>
/// <remarks>Do not implement this interface. Use one of the ReactiveViewModels instead.</remarks>
public interface IViewModel : IReactiveObject, IActivatableViewModel
{
    /// <summary>
    /// Gets or sets ViewModel`s title.
    /// </summary>
    string Title { get; set; }

    /// <summary>
    /// Gets or sets ViewModel`s DataContext.
    /// </summary>
    object? DataContext { get; set; }

    /// <summary>
    /// Gets ViewModel`s data type.
    /// </summary>
    Type? DataType { get; }

    /// <summary>
    /// Gets indication of whether or not ViewModel is busy.
    /// </summary>
    bool IsBusy { get; }
}

/// <summary>
/// Represents the base definition of ViewModel.
/// </summary>
/// <typeparam name="T">ViewModel`s data type.</typeparam>
/// <remarks>Do not implement this interface. Use one of the ReactiveViewModels instead.</remarks>
public interface IViewModel<T> : IViewModel where T : class
{
    /// <summary>
    /// Gets or sets ViewModel`s DataContext.
    /// </summary>
    public new T? DataContext { get; set; }
}
