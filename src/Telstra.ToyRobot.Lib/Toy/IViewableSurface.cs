namespace Telstra.ToyRobot.Lib.Toy;

/// <summary>
/// This is the interface that a surface must expose for the robot to be able to move on it and look at it.
/// We also use this to mock a surface for unit testing the robot.
/// </summary>
public interface IViewableSurface
{
    public bool IsValidLocation(int x, int y);
}
