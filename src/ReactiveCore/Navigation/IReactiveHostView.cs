namespace ReactiveCore.Navigation;

public interface IReactiveHostView : IViewFor, IEnableLogger { }

public interface IReactiveHostView<T> : IReactiveHostView, IViewFor<T> where T : class { }
