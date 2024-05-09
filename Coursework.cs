using System.Collections.ObjectModel;

public abstract class Coursework(string name, float earnablePoint = 100) {
    public readonly string name = name;
    public readonly int Id = _idCounter++;
    private static int _idCounter = 0;

    public abstract float GetPointEarned(ReadOnlyCollection<string> submission);

    public float EarnablePoint { get; protected set; } = earnablePoint;
    public DateTime? DueAt { get; protected set; }
    public DateTime? UnlockAt { get; protected set; }
    public DateTime? LockAt { get; protected set; }

}

