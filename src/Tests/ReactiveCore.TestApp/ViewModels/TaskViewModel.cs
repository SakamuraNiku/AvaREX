namespace ReactiveCore.TestApp.ViewModels;

using ReactiveCore.TestApp.Models;

[UrlSegment("Task")]
[HostViewContract(ByName = true)]
public class TaskViewModel : ReactiveViewModel<Task>
{
}