namespace Telstra.ToyRobot.Lib.Toy;

/// <summary>
/// Encapsulates the directions that a robot may be facing.
/// If the direction is "UNKNOWN", the robot hasn't been placed on a surface yet.
/// </summary>
public class Direction
{
    private readonly Dictionary<int, string> directions = new() { { -1, "UNKNOWN" }, { 0, "NORTH" }, { 1, "EAST" }, { 2, "SOUTH" }, { 3, "WEST" } };
    private int currentDirection = -1;

    public const string UNKNOWN = "UNKNOWN";
    public const string NORTH = "NORTH";
    public const string EAST = "EAST";
    public const string SOUTH = "SOUTH";
    public const string WEST = "WEST";

    public void Right()
    {
        if (currentDirection == -1) return;
        if (++currentDirection == 4) currentDirection = 0;
    }

    public void Left()
    {
        if (currentDirection == -1) return;
        if (--currentDirection < 0) currentDirection = 3;
    }

    public string Current
    {
        get { return directions[currentDirection]; }
        set
        {
            if (!directions.ContainsValue(value)) return;
            currentDirection = directions
                .Single(d => d.Value == value)
                .Key;
        }
    }
}