using MockCanvas.Questions;
public class Quiz(string name,List<Question> questions) : Coursework(name) {
    public List<Question> Questions { get; private set; } = questions;
}