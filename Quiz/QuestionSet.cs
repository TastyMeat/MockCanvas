namespace MockCanvas.Questions;
public class QuestionSet(string title, List<Question> questions) : Question(title, questions.Sum(question => question.Point)) {
    public List<Question> Questions { get; private set; } = questions;

    public override List<string> GetRandomAnswer() =>
        Questions.Aggregate<Question, List<string>>(
            [],
            (answers, subQuestion) => [.. answers, .. subQuestion.GetRandomAnswer()]
        );

    public override float VerifyAnswer(List<string> submission) {
        throw new NotImplementedException();
    }
}

