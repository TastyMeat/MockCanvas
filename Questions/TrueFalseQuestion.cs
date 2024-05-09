namespace MockCanvas.Questions;
public class TrueFalseQuestion(string title, bool answer) : Question(title)
{
    private readonly bool answer = answer;

    public override void AnswerWith(string answer) {
        throw new NotImplementedException();
    }
}
