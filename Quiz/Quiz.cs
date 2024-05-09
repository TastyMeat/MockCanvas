using MockCanvas.Questions;
using System.Collections.ObjectModel;
public class Quiz(string name, List<Question> questions) : Coursework(name, questions.Sum(question => question.Point)) {
    public List<Question> Questions { get; private set; } = questions;

    public override float GetPointEarned(ReadOnlyCollection<string> submission) {
        List<string> submissionCopy = new(submission);

        return Questions.Aggregate<Question, float>(0, (pointEarned, question) => {
            pointEarned += question.VerifyAnswer(submissionCopy);
            submissionCopy.RemoveAt(0);
            
            return pointEarned;
        }) / EarnablePoint;
    }
}