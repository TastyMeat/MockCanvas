namespace MockCanvas.Questions;
public abstract class Question(string title) : Coursework {
    public readonly string Title = title;

    public abstract void AnswerWith(string answer);
}

