public abstract class Coursework(float maxGrade = 100)
{
    public float GradeEarned { get; protected set; }
    public float MaxGrade { get; protected set; } = maxGrade;
    public DateTime? DueAt { get; protected set; }
    public DateTime? UnlockAt { get; protected set; }
    public DateTime? LockAt { get; protected set; }

}