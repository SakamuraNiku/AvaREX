namespace ReactiveCore.Navigation;

public interface IViewModel : IReactiveObject, IActivatableViewModel
{
    string Title { get; set; }

    object? DataContext { get; set; }

    Type? DataType { get; }

    bool IsBusy { get; set; }
}

public interface IViewModel<T> : IViewModel where T : class
{
    public new T? DataContext { get; set; }
}
