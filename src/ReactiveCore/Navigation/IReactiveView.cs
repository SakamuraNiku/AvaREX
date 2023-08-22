namespace ReactiveCore.Navigation;

public interface IReactiveView : IViewFor, IEnableLogger { }

public interface IReactiveView<T> : IReactiveView, IViewFor<T>
    where T : class, IReactiveViewModel { }
