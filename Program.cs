// See https://aka.ms/new-console-template for more information

using MockCanvas.Questions;

CanvasUser lecturer = new("Rogelio");
CanvasUser[] teachingAssistants = [
   new("Janaki"),
   new("Goutham"),
];

AcademicCourse csci152e = new("CSCI 152E", "Spring 2024");
csci152e.Enroll(lecturer, AcademicCourse.RoleTypes.Teacher);
foreach (CanvasUser teachingAssistant in teachingAssistants) csci152e.Enroll(teachingAssistant, AcademicCourse.RoleTypes.TeachingAssistant);

CanvasUser[] students = [
    new("Ren Hao Wong"),
    new("Zheng Wei Ng"),
    new("Ryan Mcarthur"),
    new("Jake Alvarado"),
    new("Jad Kang"),
];

foreach (CanvasUser student in students) student.EnrollIn(csci152e);


Quiz quiz1 = new("Quiz 1", [
    new ChoiceQuestion("Pick a number", 5),
    new TrueFalseQuestion("Is this a question", true),
]);

csci152e.AssignCoursework(quiz1);

Quiz quiz2 = new("Quiz 2", [
    new ChoiceQuestion("Pick a number", 5),
    new TrueFalseQuestion("Is this a question", true),
    new QuestionSet("Set", [
        new ChoiceQuestion("Pick a number", 5),
        new TrueFalseQuestion("Is this a question", true),
    ]),
]);

csci152e.AssignCoursework(quiz2);

foreach (CanvasUser student in students) csci152e.GetGrade(student);