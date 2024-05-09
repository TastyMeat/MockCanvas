using System.Collections.ObjectModel;

namespace MockCanvas;

public class Assignment(string name, float point) : Coursework(name, point) {
    public override float GetPointEarned(ReadOnlyCollection<string> submission) => 0;
}