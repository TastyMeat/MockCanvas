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
    /// gets and set the Name
    /// </summary>
    public string Name { get; set; } = name;
     /// <summary>
    /// gets and set the Weight
    /// </summary>
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
    /// gets and sets the earnable point of the coursework
    /// </summary>
    public float EarnablePoint { get; protected set; } = earnablePoint;

    /// <summary>
    /// gets and sets the due at time
    /// </summary>
    public DateTime? DueAt { get; protected set; }

    /// <summary>
    /// gets and sets the unlock at time
    /// </summary>
    public DateTime? UnlockAt { get; protected set; }

    /// <summary>
    /// gets and sets the lock at time
    /// </summary>
    public DateTime? LockAt { get; protected set; }

}

