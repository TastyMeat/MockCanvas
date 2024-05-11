namespace MockCanvas.Education;
/// <summary>
/// Represents a true/false question in a quiz.
/// </summary>
public class TrueFalseQuestion(string title, bool answer, int earnablePoint = 1) : Question(title, earnablePoint)
{
    private readonly bool answer = answer;

    public override List<string> GetRandomAnswer() => [GetRandomTrueFalseAnswer().ToString()];

    private static bool GetRandomTrueFalseAnswer() => new Random().Next(2) == 1;
    /// <summary>
    /// Calculates the points earned for the submission of the true/false question.
    /// </summary>
    /// <param name="submissionCopy"></param>
    /// <param name="indent"></param>
    /// <returns></returns>
    public override float GetSubmissionPoint(List<string> submissionCopy, int indent = 0)
    {
        // Attempt to parse the first submission answer as a boolean. If succesful, compare the submitted answer with the correct answer, if it is incorrect or it fails it will assign 0 points
        float pointEarned = bool.TryParse(submissionCopy.First(), out bool submittedAnswer)
            ? submittedAnswer == answer
                ? EarnablePoint
                : 0
            : 0;

        Console.WriteLine($"{new('\t', indent)}{pointEarned} / {EarnablePoint} > \"{Title}\" | Answered: {submissionCopy.First()}");

        // Remove the processed submission from the copy.
        submissionCopy.RemoveAt(0);

        return pointEarned;
    }
}
