namespace MockCanvas.Questions;
public abstract class Question(string title, float point) {
    public readonly string Title = title;
    public readonly float Point = point;

    public abstract void AnswerWith(string answer);

    public abstract List<string> GetRandomAnswer();

    public abstract float VerifySubmission(List<string> submission);
}

