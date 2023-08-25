namespace ReactiveCore.TestApp.ViewModels;

[UrlSegment("Project")]
[HostViewContract(ByName = true)]
public class ProjectViewModel : ReactiveViewModel<Project>
{
}