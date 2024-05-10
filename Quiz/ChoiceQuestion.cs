
namespace MockCanvas.Questions;
public class ChoiceQuestion(string title, int answer, float point = 1) : Question(title, point) {

    private readonly int Answer = answer;

    public override List<string> GetRandomAnswer() => [GetRandomChoiceAnswer().ToString()];

    private static int GetRandomChoiceAnswer() => new Random().Next(1, 6);

    public override float GetSubmissionPoint(List<string> submission) {
        float point = int.TryParse(submission.First(), out int submittedAnswer)
            ? submittedAnswer == Answer
                ? Point
                : 0
            : 0;

        submission.RemoveAt(0);
        return point;
    }
}