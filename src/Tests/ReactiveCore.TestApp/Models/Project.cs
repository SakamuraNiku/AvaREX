namespace ReactiveCore.TestApp.Models;

public class Project
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Task> Tasks { get; } = new List<Task>();
}