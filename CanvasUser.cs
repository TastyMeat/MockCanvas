using MockCanvas.Questions;
using System.Collections.ObjectModel;

public class CanvasUser(string name) {

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
		if(!Enrollments.Contains(course)) Enrollments.Add(course);
	}

    private Coursework[] GetTasks() {
		return [];
	}

	public List<string> Mock_AnswerQuestion(Question question) {
		return question switch {
			ChoiceQuestion => [GetRandomChoiceAnswer().ToString()],
			TrueFalseQuestion => [GetRandomTrueFalseAnswer().ToString()],

			QuestionSet questionSet => new Func<List<string>>(() => {
                foreach (Question subQuestion in questionSet.Questions)
                    Mock_AnswerQuestion(subQuestion);
                return []; 
			})(),

			_ => [],
		};
	}

	private static int GetRandomChoiceAnswer() => new Random().Next(1, 6);
	private static bool GetRandomTrueFalseAnswer()=> new Random().Next(2) == 1;
}