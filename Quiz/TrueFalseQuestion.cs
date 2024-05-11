
namespace MockCanvas.Questions;
public class TrueFalseQuestion(string title, bool answer, int earnablePoint = 1) : Question(title, earnablePoint) {
    private readonly bool answer = answer;

    public override List<string> GetRandomAnswer() => [GetRandomTrueFalseAnswer().ToString()];

    private static bool GetRandomTrueFalseAnswer() => new Random().Next(2) == 1;

    public override float GetSubmissionPoint(List<string> submissionCopy, int indent = 0) {
        float pointEarned = bool.TryParse(submissionCopy.First(), out bool submittedAnswer)
            ? submittedAnswer == answer
                ? EarnablePoint
                : 0
            : 0;

        Console.WriteLine($"{new('\t', indent)}{pointEarned} / {EarnablePoint} > \"{Title}\" | Answered: {submissionCopy.First()}");

        submissionCopy.RemoveAt(0);

        return pointEarned;
    }
}
