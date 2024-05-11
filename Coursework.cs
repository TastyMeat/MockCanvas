using System.Collections.ObjectModel;

public abstract class Coursework(string name, float weight, float earnablePoint = 100) {
    public string Name { get; set; } = name;
    public float Weight { get; set; } = weight;

    public readonly int Id = _idCounter++;
    private static int _idCounter = 0;

    public abstract float GetPointEarned(ReadOnlyCollection<string> submission);

    public float EarnablePoint { get; protected set; } = earnablePoint;
    public DateTime? DueAt { get; protected set; }
    public DateTime? UnlockAt { get; protected set; }
    public DateTime? LockAt { get; protected set; }

}

