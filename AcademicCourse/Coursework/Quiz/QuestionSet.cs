namespace MockCanvas.Education;
public class QuestionSet(string title, List<Question> questions) : Question(title, questions.Sum(question => question.EarnablePoint))
{
    public List<Question> Questions { get; private set; } = questions;

    public override List<string> GetRandomAnswer() =>
        Questions.Aggregate<Question, List<string>>(
            [],
            (answers, subQuestion) => [.. answers, .. subQuestion.GetRandomAnswer()]
        );

    public override float GetSubmissionPoint(List<string> submissionCopy, int indent = 0)
    {
        Console.WriteLine($"\"{Title}\":");

        return Questions.Sum(question => question.GetSubmissionPoint(submissionCopy, indent + 1));
    }
}

