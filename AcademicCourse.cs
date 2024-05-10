using MockCanvas.Questions;

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

    public void Disenroll(CanvasUser user) => Users.Remove(user);
    #endregion

    #region Courseworks
    public void AssignCoursework(Coursework coursework) {
        Courseworks.Add(coursework);
        Console.WriteLine($"Assigned coursework {coursework.name} in {Name}.");

        foreach (CanvasUser user in Users.Where(user => Roles[user.Id] == RoleTypes.Student))
            user.OnCourseworkAssigned(this, coursework);
    }

    public void SubmitCoursework(CanvasUser user, int courseworkId, List<string> submission) {
        var userSubmissions = Submissions[user.Id];

        if (!userSubmissions.TryAdd(courseworkId, submission)) userSubmissions[courseworkId] = submission;
    }

    public void GetGrade(CanvasUser user) {
        var userSubmissions = Submissions[user.Id];


        userSubmissions.ToList().ForEach(keyValuePair => {
            float pointEarned = Courseworks.Find(coursework => coursework.Id == keyValuePair.Key)?.GetPointEarned(keyValuePair.Value.AsReadOnly()) ?? 0;
            Console.WriteLine(pointEarned);
        });

        //(float pointsEarned, float earnablePoints) = userSubmissions.Values.Aggregate<Coursework, (float pointsEarned, float earnablePoints)>((0, 0), (sum,coursework) => {

        //    return (sum.pointsEarned + coursework.PointEarned ?? 0, sum.earnablePoints + coursework.EarnablePoint);
        //});

        //float grade = pointsEarned / earnablePoints;
    }
    #endregion
}

public interface ICourseListener {
    void OnCourseworkAssigned(AcademicCourse course, Coursework coursework);
}