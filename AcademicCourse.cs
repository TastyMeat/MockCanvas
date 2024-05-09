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
    }

    public void Disenroll(CanvasUser user) => Users.Remove(user);
    #endregion

    #region Courseworks
    public void AssignCoursework(Coursework coursework) {
        foreach (CanvasUser user in Users.Where(user => Roles[user.Id] == RoleTypes.Student)) {
            switch (coursework) {
                case Question question: 
                    user.Mock_AnswerQuestion(question); 
                    break;
            }
        }
    }

    public void SubmitCoursework(CanvasUser user, Coursework coursework) {
        var userSubmissions = Submissions[user.Id];

        //if (!userSubmissions.TryAdd(coursework.Id, coursework)) userSubmissions[coursework.Id] = coursework;
    }

    public void GetGrade(CanvasUser user) {
        var userSubmissions = Submissions[user.Id];

        //(float pointsEarned, float earnablePoints) = userSubmissions.Values.Aggregate<Coursework, (float pointsEarned, float earnablePoints)>((0, 0), (sum,coursework) => {

        //    return (sum.pointsEarned + coursework.PointEarned ?? 0, sum.earnablePoints + coursework.EarnablePoint);
        //});

        //float grade = pointsEarned / earnablePoints;
    }
    #endregion
}