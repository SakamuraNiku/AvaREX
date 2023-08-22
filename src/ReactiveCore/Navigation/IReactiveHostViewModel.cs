namespace ReactiveCore.Navigation;

public interface IReactiveHostViewModel : IViewModel, IScreen { }

public interface IReactiveHostViewModel<T> : IReactiveHostViewModel, IViewModel<T> where T : class { }
