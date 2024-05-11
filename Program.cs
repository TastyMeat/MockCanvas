// See https://aka.ms/new-console-template for more information

using MockCanvas.Education;
using MockCanvas.User;

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

Console.WriteLine();

Quiz quiz1 = new("Quiz 1", 0.15f, [
    new ChoiceQuestion("Pick the number 5: ", 5),
    new TrueFalseQuestion("Is this a question?", true),
]);

csci152e.AssignCoursework(quiz1);
Console.WriteLine();

Quiz quiz2 = new("Quiz 2", 0.2f, [
    new ChoiceQuestion("Pick the number 5: ", 5),
    new TrueFalseQuestion("Is this a question?", true),
    new QuestionSet("Here's a question set: ", [
        new ChoiceQuestion("Pick the number 5: ", 5),
        new TrueFalseQuestion("Is this a question?", true),
    ]),
]);

csci152e.AssignCoursework(quiz2);
Console.WriteLine();

foreach (CanvasUser student in students) csci152e.GetGrade(student);