using System.Collections.ObjectModel;

namespace MockCanvas.Education;
/// <summary>
/// Initializes a new instance of the <see cref="Assignment"/> class with the specified parameters.
/// </summary>
/// <param name="name">The name of the assignment.</param>
/// <param name="weight">The weight of the assignment in the overall course grading.</param>
/// <param name="point">The total points possible for the assignment.</param>
public class Assignment(string name, float weight, float point) : Coursework(name, weight, point)
{
    /// <summary>
    /// Calculates the points earned for the assignment based on the submitted answers.
    /// </summary>
    /// <param name="submission">A read-only collection of strings representing the submitted answers.</param>
    /// <returns>The points earned for the assignment, which is always 0 for this implementation.</returns>
    public override float GetPointEarned(ReadOnlyCollection<string> submission) => 0;
}