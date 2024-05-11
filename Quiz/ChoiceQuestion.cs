
namespace MockCanvas.Questions;
public class ChoiceQuestion(string title, int answer, float point = 1) : Question(title, point) {

    private readonly int Answer = answer;

    public override List<string> GetRandomAnswer() => [GetRandomChoiceAnswer().ToString()];

    private static int GetRandomChoiceAnswer() => new Random().Next(1, 6);

    public override float GetSubmissionPoint(List<string> submissionCopy, int indent = 0) {
        float pointEarned = int.TryParse(submissionCopy.First(), out int submittedAnswer)
            ? submittedAnswer == Answer
                ? EarnablePoint
                : 0
            : 0;

        Console.WriteLine($"{new('\t', indent)}{pointEarned} / {EarnablePoint} > \"{Title}\" | Answered: {submissionCopy.First()}");

        submissionCopy.RemoveAt(0);
        return pointEarned;
    }
}