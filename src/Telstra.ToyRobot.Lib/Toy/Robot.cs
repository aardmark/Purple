namespace Telstra.ToyRobot.Lib.Toy;

/// <summary>
/// The Robot class.
/// </summary>
public class Robot
{
    private int x;
    private int y;
    private readonly Direction direction = new();
    private readonly IViewableSurface surface;

    public Robot(IViewableSurface surface)
    {
        this.surface = surface;
    }

    public void Move()
    {
        var (newx, newy) = (x, y);
        switch(direction.Current)
        {
            case Direction.UNKNOWN: return;
            case Direction.NORTH: ++newy; break;
            case Direction.EAST: ++newx; break;
            case Direction.SOUTH: --newy; break;
            case Direction.WEST: --newx; break;
        }
        // have the robot "look at" where it wants to go and move there if it's a valid location
        if (surface.IsValidLocation(newx, newy))
        {
            (x, y) = (newx, newy);
        }
    }

    public void TurnLeft()
    {
        direction.Left();
    }

    public void TurnRight()
    {
        direction.Right();
    }

    public string Report()
    {
        if (direction.Current == Direction.UNKNOWN) return string.Empty;
        return $"{x},{y},{direction.Current}";
    }

    public void Place(int newX, int newY, string newDirection = "")
    {
        if (string.IsNullOrEmpty(newDirection) && direction.Current == Direction.UNKNOWN) return;
        if (!surface.IsValidLocation(newX, newY)) return;

        (x, y) = (newX, newY);
        if (!string.IsNullOrEmpty(newDirection)) direction.Current = newDirection;
    }
}
