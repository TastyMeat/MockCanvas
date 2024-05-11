namespace MockCanvas.Education;
/// <summary>
/// QuestionSet class that implements the question abstract question
/// </summary>
/// <param name="title"></param>
/// <param name="questions"></param>
public class QuestionSet(string title, List<Question> questions) : Question(title, questions.Sum(question => question.EarnablePoint))
{
    public List<Question> Questions { get; private set; } = questions;
    /// <summary>
    /// Generates a random answer for the composite question
    /// </summary>
    /// <returns></returns>
    public override List<string> GetRandomAnswer() =>
        Questions.Aggregate<Question, List<string>>(
            [],
            (answers, subQuestion) => [.. answers, .. subQuestion.GetRandomAnswer()]
        );
    /// <summary>
    /// Calculates the total points earned for the submission of the composite question by summing up points earned from its sub-questions.
    /// </summary>
    /// <param name="submissionCopy"></param>
    /// <param name="indent"></param>
    /// <returns></returns>
    public override float GetSubmissionPoint(List<string> submissionCopy, int indent = 0)
    {
        Console.WriteLine($"\"{Title}\":");

        return Questions.Sum(question => question.GetSubmissionPoint(submissionCopy, indent + 1));
    }
}

