namespace MockCanvas.Education;
/// <summary>
/// Choice Question class that implements the Question abstract class
/// </summary>
/// <param name="title"></param>
/// <param name="answer"></param>
/// <param name="point"></param>
public class ChoiceQuestion(string title, int answer, float point = 1) : Question(title, point)
{

    private readonly int Answer = answer;
    
    public override List<string> GetRandomAnswer() => [GetRandomChoiceAnswer().ToString()];
    /// <summary>
    /// Generates a random choice answer.
    /// generates a random number between 1 - 5
    /// </summary>
    private static int GetRandomChoiceAnswer() => new Random().Next(1, 6);
    /// <summary>
    /// Calculates the points earned for the submission of the multiple choice question.
    /// </summary>
    /// <param name="submissionCopy"></param>
    /// <param name="indent"></param>
    /// <returns></returns>
    public override float GetSubmissionPoint(List<string> submissionCopy, int indent = 0)
    {
        // Attempt to parse the first submission answer as a boolean. If succesful, compare the submitted answer with the correct answer, if it is incorrect or it fails it will assign 0 points
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