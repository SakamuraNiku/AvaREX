namespace ReactiveCore.TestApp.ViewModels;

using ReactiveCore.TestApp.Models;

[UrlSegment("Tasks")]
[HostViewContract(Contract = "Tasks")]
public class TasksViewModel : ReactiveViewModel<ICollection<Task>>
{
}