using MockCanvas.Questions;
public class Quiz() : Coursework {
    private QuestionSet questionSet;
    public Quiz(QuestionSet questionSet) : this()
    {
        this.questionSet = questionSet;
    }
}