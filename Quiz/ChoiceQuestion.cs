
namespace MockCanvas.Questions;
public class ChoiceQuestion(string title, int answer, float point = 1) : Question(title, point) {

    private readonly int Answer = answer;

    public override void AnswerWith(string answer) {
        throw new NotImplementedException();
    }

    public override List<string> GetRandomAnswer() => [GetRandomChoiceAnswer().ToString()];

    private static int GetRandomChoiceAnswer() => new Random().Next(1, 6);

    public override float VerifySubmission(List<string> submission) =>
        int.TryParse(submission.First(), out int submittedAnswer)
            ? submittedAnswer == answer
                ? Point
                : 0
            : 0;
}