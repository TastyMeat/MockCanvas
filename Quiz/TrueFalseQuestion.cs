
namespace MockCanvas.Questions;
public class TrueFalseQuestion(string title, bool answer, int point = 1) : Question(title, point) {
    private readonly bool answer = answer;

    public override List<string> GetRandomAnswer() => [GetRandomTrueFalseAnswer().ToString()];

    private static bool GetRandomTrueFalseAnswer() => new Random().Next(2) == 1;

    public override float VerifyAnswer(List<string> submission) {
        float point = bool.TryParse(submission.First(), out bool submittedAnswer)
            ? submittedAnswer == answer
                ? Point
                : 0
            : 0;

        submission.RemoveAt(0);
        return point;
    }
}
