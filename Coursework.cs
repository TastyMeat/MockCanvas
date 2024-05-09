public abstract class Coursework(float maxPoint = 100) {
    public float? PointEarned { get; protected set; }
    public float MaxPoint { get; protected set; } = maxPoint;
    public DateTime? DueAt { get; protected set; }
    public DateTime? UnlockAt { get; protected set; }
    public DateTime? LockAt { get; protected set; }
}