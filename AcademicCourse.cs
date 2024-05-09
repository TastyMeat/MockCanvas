public class AcademicCourse(string name, string semester) {

    public string Name { get; private set; } = name;
    public string Semester { get; private set; } = semester;

    public List<CanvasUser> Users { get; private set; } = [];
    public Dictionary<int, GradeReport> Grades { get; private set; } = [];
    public enum RoleTypes {
        Teacher,
        TeachingAssistant,
        PeerReview,
        Student,
    }
    public Dictionary<int, RoleTypes> Roles { get; private set; } = [];


    public List<Coursework> Courseworks { get; private set; } = [];

    #region Users
    public void Enroll(CanvasUser user, RoleTypes role = RoleTypes.Student) {
        if (Users.Contains(user)) return;

        Users.Add(user);
        Grades.TryAdd(user.Id, new());
        Roles.TryAdd(user.Id, role);

        user.EnrollIn(this);
    }

    public void Disenroll(CanvasUser user) => Users.Remove(user);
    #endregion

    #region Courseworks
    public void AssignCoursework(Coursework coursework) {
        foreach (CanvasUser user in Users.Where(user => Roles[user.Id] == RoleTypes.Student)) {
            // notify
        }
    }
    #endregion
}