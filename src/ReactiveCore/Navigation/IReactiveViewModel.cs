namespace ReactiveCore.Navigation;

public interface IReactiveViewModel : IViewModel, IRoutableViewModel { }

public interface IReactiveViewModel<T> : IViewModel<T>, IRoutableViewModel where T : class { }
