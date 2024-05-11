using System.Collections.ObjectModel;

namespace MockCanvas;

public class Assignment(string name, float weight, float point) : Coursework(name, weight, point) {
    public override float GetPointEarned(ReadOnlyCollection<string> submission) => 0;
}