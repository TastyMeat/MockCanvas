namespace MockCanvas.Questions;
public class ChoiceQuestion(string title, int answer) : Question(title) {

    private readonly int Answer = answer;

    public override void AnswerWith(string answer) {
        throw new NotImplementedException();
    }
}

