using System.Collections.ObjectModel;

namespace MockCanvas.Education;
/// <summary>
/// class that represents the Quiz
/// </summary>
/// <param name="name"></param>
/// <param name="weight"></param>
/// <param name="questions"></param>
public class Quiz(string name, float weight, List<Question> questions) : Coursework(name, weight, questions.Sum(question => question.EarnablePoint))
{
    public List<Question> Questions { get; private set; } = questions;
    /// <summary>
    /// Calculates the points earned for the submission of all questions in the quiz.
    /// </summary>
    /// <param name="submission"></param>
    /// <returns> the weight multiplied by the points earned and divided by the earnable points</returns>
    public override float GetPointEarned(ReadOnlyCollection<string> submission)
    {
        List<string> submissionCopy = new(submission);

        Console.WriteLine($"Result for {Name} ({string.Format("{0:.##}", Weight * 100)} %):");

        float pointEarned = Questions.Aggregate<Question, float>(0, (pointEarned, question) =>
        {
            pointEarned += question.GetSubmissionPoint(submissionCopy);

            return pointEarned;
        });
         
        //prints in console the score
        Console.WriteLine($"Total: {pointEarned} / {EarnablePoint}");
        Console.WriteLine();

        return Weight * pointEarned / EarnablePoint;
    }
}