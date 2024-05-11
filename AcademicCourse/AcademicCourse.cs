using MockCanvas.User;

namespace MockCanvas.Education;

public class AcademicCourse(string name, string semester) {

    public string Name { get; private set; } = name;
    public string Semester { get; private set; } = semester;

    public List<CanvasUser> Users { get; private set; } = [];
    public enum RoleTypes {
        Teacher,
        TeachingAssistant,
        PeerReview,
        Student,
    }
    public Dictionary<int, RoleTypes> Roles { get; private set; } = [];


    public CanvasUser? Teacher => _teacher ??= Users.Find(user => user.Id == Roles.First(role => role.Value == RoleTypes.Teacher).Key);
    private CanvasUser? _teacher;

    public List<Coursework> Courseworks { get; private set; } = [];

    public Dictionary<int, Dictionary<int, List<string>>> Submissions { get; private set; } = [];

    #region Users
    public void Enroll(CanvasUser user, RoleTypes role = RoleTypes.Student) {
        if (Users.Contains(user)) return;

        Users.Add(user);
        Roles.TryAdd(user.Id, role);
        Submissions.TryAdd(user.Id, []);

        user.EnrollIn(this);

        Console.WriteLine($"Enrolled {user.Name} in {Name} as a {Roles[user.Id]}.");
    }

    public void Disenroll(CanvasUser user) {
        if (Roles[user.Id] == RoleTypes.Teacher) _teacher = null;
        Users.Remove(user);
    }
    #endregion

    #region Courseworks
    public void AssignCoursework(Coursework coursework) {
        Courseworks.Add(coursework);

        if (Teacher != null)
            Console.Write($"{Teacher.Name} assigned ");
        else
            Console.Write($"Assigned ");

        Console.WriteLine($"coursework {coursework.Name} in {Name}.");

        foreach (CanvasUser user in Users.Where(user => Roles[user.Id] == RoleTypes.Student))
            user.OnCourseworkAssigned(this, coursework);
    }

    public void SubmitCoursework(CanvasUser user, int courseworkId, List<string> submission) {
        var userSubmissions = Submissions[user.Id];

        if (!userSubmissions.TryAdd(courseworkId, submission)) userSubmissions[courseworkId] = submission;
    }

    public void GetGrade(CanvasUser user) {
        Console.WriteLine($"Retrieving grades for {user.Name} in {Name}:");
        var userSubmissions = Submissions[user.Id];

        float pointEarned = userSubmissions.Sum(keyValuePair => {
            Coursework? coursework = Courseworks.Find(coursework => coursework.Id == keyValuePair.Key);

            return coursework?.GetPointEarned(keyValuePair.Value.AsReadOnly()) ?? 0;
        });

        float earnablePoint = Courseworks.Select(coursework => coursework.Weight).Sum();

        Console.WriteLine($"Current standing: {string.Format("{0:.##}", pointEarned * 100)} / {string.Format("{0:.##}", earnablePoint * 100)} %");
        Console.WriteLine();
    }
    #endregion
}

public interface ICourseListener {
    void OnCourseworkAssigned(AcademicCourse course, Coursework coursework);
}