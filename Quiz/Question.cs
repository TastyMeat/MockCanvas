namespace MockCanvas.Questions;
public abstract class Question(string title, float point) {
    public readonly string Title = title;
    public readonly float EarnablePoint = point;

    public abstract List<string> GetRandomAnswer();

    public abstract float GetSubmissionPoint(List<string> submissionCopy, int indent = 0);
}

