using MockCanvas.Questions;
using System.Collections.ObjectModel;

public class CanvasUser(string name) : ICourseListener {

    public readonly int Id = _idCounter++;
    private static int _idCounter = 0;

    public string Name { get; private set; } = name;
    public string Contact { get; private set; } = "";
    public string Biography { get; private set; } = "";

    private List<AcademicCourse> Enrollments { get; set; } = [];

    public ReadOnlyCollection<Uri> Links => new(_links);
    private readonly List<Uri> _links = [];


    public void EnrollIn(AcademicCourse course) {
        course.Enroll(this);
        if (!Enrollments.Contains(course)) Enrollments.Add(course);
    }

    private Coursework[] GetTasks() {
        return [];
    }

    public void OnCourseworkAssigned(AcademicCourse course, Coursework coursework) {
        List<string> submission = coursework switch {
            Quiz quiz => Mock_AnswerQuiz(quiz),
            _ => throw new NotImplementedException()
        };

        course.SubmitCoursework(this, coursework.Id, submission);
    }

    private static List<string> Mock_AnswerQuiz(Quiz quiz) =>
        quiz.Questions.Aggregate<Question, List<string>>([], (submission, question) =>
                [.. submission, .. question.GetRandomAnswer()]);
}