namespace MockCanvas.Questions;
public class QuestionSet(string title, List<Question> questions) : Question(title)
{
    public List<Question> Questions { get; private set; } = questions;

    public override void AnswerWith(string answer) {
        throw new NotImplementedException();
    }
}

