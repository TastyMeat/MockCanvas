
namespace MockCanvas.Questions;
public class TrueFalseQuestion(string title, bool answer, int point = 1) : Question(title, point) {
    private readonly bool answer = answer;

    public override List<string> GetRandomAnswer() => [GetRandomTrueFalseAnswer().ToString()];

    private static bool GetRandomTrueFalseAnswer() => new Random().Next(2) == 1;

    public override float GetSubmissionPoint(List<string> submissionCopy) {
        float point = bool.TryParse(submissionCopy.First(), out bool submittedAnswer)
            ? submittedAnswer == answer
                ? Point
                : 0
            : 0;

        submissionCopy.RemoveAt(0);
        return point;
    }
}
