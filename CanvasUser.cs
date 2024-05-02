using System.Collections.ObjectModel;

public class CanvasUser(string name) {

    public string Name { get; private set; } = name;
	public string Contact { get; private set; } = "";
	public string Biography { get; private set; } = "";

	public object? Enrollments => null;

	public ReadOnlyCollection<Uri> Links => new(_links);
    private readonly List<Uri> _links = [];
}