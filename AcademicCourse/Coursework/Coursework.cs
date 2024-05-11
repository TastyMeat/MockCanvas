using System.Collections.ObjectModel;

namespace MockCanvas.Education;
/// <summary>
/// Initializes a new instance of the Coursework class with the specified parameters.
/// </summary>
/// <param name="name">The name of the coursework.</param>
/// <param name="weight">The weight of the coursework in the overall course grading.</param>
/// <param name="earnablePoint">The maximum points that can be earned for the coursework (default is 100).</param>
public abstract class Coursework(string name, float weight, float earnablePoint = 100)
{
    /// <summary>
    /// gets and set the Name and Weight
    /// </summary>
    public string Name { get; set; } = name;
    public float Weight { get; set; } = weight;

    /// <summary>
    /// gets unique id for the coursework 
    /// </summary>
    public readonly int Id = _idCounter++;
    private static int _idCounter = 0;
    /// <summary>
    /// gets the points earned from the submission
    /// </summary>
    /// <param name="submission"></param>
    /// <returns></returns>
    public abstract float GetPointEarned(ReadOnlyCollection<string> submission);

    /// <summary>
    /// gets and sets the date time of the dua at, unlock at, lock at time and the earnable point of the coursework
    /// </summary>
    public float EarnablePoint { get; protected set; } = earnablePoint;
    public DateTime? DueAt { get; protected set; }
    public DateTime? UnlockAt { get; protected set; }
    public DateTime? LockAt { get; protected set; }

}

