using System.Collections.ObjectModel;

using MockCanvas.Education;

namespace MockCanvas.User;
/// <summary>
/// Canvas User Class  implements the ICourseListener Interface
/// has a readonly int Id which will increment the idCounter
/// and an private idCounter that is initalized to 0 
/// includes the Name, Contact and Biography of the CanvasUser
/// includes a lot of functions necessary for Canvas to function (comments included below)
/// </summary>
/// <param name="name"></param>
public class CanvasUser(string name) : ICourseListener {

    public readonly int Id = _idCounter++;
    private static int _idCounter = 0;

    public string Name { get; private set; } = name;
    public string Contact { get; private set; } = "";
    public string Biography { get; private set; } = "";

    private List<AcademicCourse> Enrollments { get; set; } = [];

    public ReadOnlyCollection<Uri> Links => new(_links);
    private readonly List<Uri> _links = [];

/// <summary>
/// Enrolls the current student in the specified academic course.
/// </summary>
/// <param name="course">The academic course to be enrolled in.</param>
    public void EnrollIn(AcademicCourse course) {
        course.Enroll(this);
        if (!Enrollments.Contains(course)) Enrollments.Add(course);
    }

    private Coursework[] GetTasks() {
        return [];
    }
/// <summary>
/// OnCourseworkAssigned will take in course, and coursework and 
/// prints in console saying Which user received coursework and its name and which course it is from
/// prints in console saying Which user is working on what coursework
/// It will call the Mock_CompleteQuiz or Mock_CompleteAssignment depending on the case
/// It will also submit the coursework and print in the console that the User has submitted which coursework
/// </summary>
/// <param name="course"></param>
/// <param name="coursework"></param>
/// <exception cref="NotImplementedException"></exception>
    public void OnCourseworkAssigned(AcademicCourse course, Coursework coursework) {
        Console.WriteLine($"{Name} received coursework {coursework.Name} from {course.Name}.");

        Console.WriteLine($"{Name} working on coursework {coursework.Name}...");
        List<string> submission = coursework switch {
            Quiz quiz => Mock_CompleteQuiz(quiz),
            Assignment assignment => Mock_CompleteAssignment(assignment),
            _ => throw new NotImplementedException()
        };

        course.SubmitCoursework(this, coursework.Id, submission);
        Console.WriteLine($"{Name} submitted coursework {coursework.Name}.");
    }
/// <summary>
/// Mocks the completion of a quiz by generating a list of random answers for each question.
/// </summary>
/// <param name="quiz">The quiz object containing the questions to be completed.</param>
/// <returns>A list of strings representing random answers for each question in the quiz.</returns>
    private static List<string> Mock_CompleteQuiz(Quiz quiz) =>
        quiz.Questions.Aggregate<Question, List<string>>([], (submission, question) =>
                [.. submission, .. question.GetRandomAnswer()]);
/// <summary>
/// Mocks the completion of an assignment by throwing a NotImplementedException.
/// </summary>
/// <param name="assignment">The assignment object representing the task to be completed.</param>
/// <exception cref="NotImplementedException"></exception>
    private static List<string> Mock_CompleteAssignment(Assignment assignment) => throw new NotImplementedException();
}