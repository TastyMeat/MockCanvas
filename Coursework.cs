public abstract class Coursework(float earnablePoint = 100) {

    public readonly int Id = _idCounter++;
    private static int _idCounter = 0;

    public float? PointEarned { get; protected set; }
    public float EarnablePoint { get; protected set; } = earnablePoint;
    public DateTime? DueAt { get; protected set; }
    public DateTime? UnlockAt { get; protected set; }
    public DateTime? LockAt { get; protected set; }

}