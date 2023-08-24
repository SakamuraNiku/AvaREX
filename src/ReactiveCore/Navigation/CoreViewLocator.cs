namespace ReactiveCore.Navigation;

public class CoreViewLocator : IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        throw new NotImplementedException();
    }
}