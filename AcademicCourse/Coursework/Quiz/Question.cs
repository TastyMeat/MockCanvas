namespace MockCanvas.Education;
/// <summary>
/// an abstract class for question in a quiz.
/// generates a question with title and point assigned
/// </summary>
/// <param name="title"></param>
/// <param name="point"></param>
public abstract class Question(string title, float point)
{
    public readonly string Title = title;
    public readonly float EarnablePoint = point;
    // Generates a random answer for the question.
    public abstract List<string> GetRandomAnswer();
    // Calculates the points earned for the submission of the question.
    public abstract float GetSubmissionPoint(List<string> submissionCopy, int indent = 0);
}

