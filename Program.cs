// See https://aka.ms/new-console-template for more information

using MockCanvas.Education;
using MockCanvas.User;
// initializes a lecturer called rogelio
CanvasUser lecturer = new("Rogelio");
// initializes teaching assistants janaki and goutham
CanvasUser[] teachingAssistants = [
   new("Janaki"),
   new("Goutham"),
];
// initializes the course csci152e and with CSCI 152E and term Spring 2024
AcademicCourse csci152e = new("CSCI 152E", "Spring 2024");
// enroll lecturer to the academic course
csci152e.Enroll(lecturer, AcademicCourse.RoleTypes.Teacher);
// enroll the ta to the academic course
foreach (CanvasUser teachingAssistant in teachingAssistants) csci152e.Enroll(teachingAssistant, AcademicCourse.RoleTypes.TeachingAssistant);

// initialize 5 students 
CanvasUser[] students = [
    new("Ren Hao Wong"),
    new("Zheng Wei Ng"),
    new("Ryan Mcarthur"),
    new("Jake Alvarado"),
    new("Jad Kang"),
];

// enrolls all the student into the course
foreach (CanvasUser student in students) student.EnrollIn(csci152e);

Console.WriteLine();

// initializes quiz 1 with choice question and true false question
Quiz quiz1 = new("Quiz 1", 0.15f, [
    new ChoiceQuestion("Pick the number 5: ", 5),
    new TrueFalseQuestion("Is this a question?", true),
]);

// assigns quiz1 to the course
csci152e.AssignCoursework(quiz1);
Console.WriteLine();

// assigns quiz2 with choice question, true false question and a question set 
Quiz quiz2 = new("Quiz 2", 0.2f, [
    new ChoiceQuestion("Pick the number 5: ", 5),
    new TrueFalseQuestion("Is this a question?", true),
    new QuestionSet("Here's a question set: ", [
        new ChoiceQuestion("Pick the number 5: ", 5),
        new TrueFalseQuestion("Is this a question?", true),
    ]),
]);
// assigns quiz2 to the course
csci152e.AssignCoursework(quiz2);
Console.WriteLine();

//get the grade of the students
foreach (CanvasUser student in students) csci152e.GetGrade(student);