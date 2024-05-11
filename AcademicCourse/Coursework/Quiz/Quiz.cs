using System.Collections.ObjectModel;

namespace MockCanvas.Education;

public class Quiz(string name, float weight, List<Question> questions) : Coursework(name, weight, questions.Sum(question => question.EarnablePoint)) {
    public List<Question> Questions { get; private set; } = questions;

    public override float GetPointEarned(ReadOnlyCollection<string> submission) {
        List<string> submissionCopy = new(submission);

        Console.WriteLine($"Result for {Name} ({string.Format("{0:.##}", Weight * 100)} %):");

        float pointEarned = Questions.Aggregate<Question, float>(0, (pointEarned, question) => {
            pointEarned += question.GetSubmissionPoint(submissionCopy);

            return pointEarned;
        });

        Console.WriteLine($"Total: {pointEarned} / {EarnablePoint}");
        Console.WriteLine();

        return Weight * pointEarned / EarnablePoint;
    }
}