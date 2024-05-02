public class AcademicCourseParticipant(CanvasUser canvasUser, AcademicCourseParticipant.RoleTypes role) {
    public enum RoleTypes {
        Teacher,
        TA,
        PeerReview,
        Student,
    }

    public CanvasUser CanvasUser { get; private set; } = canvasUser;
    public RoleTypes Role { get; private set; } = role;
}
