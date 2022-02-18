using Telstra.ToyRobot.Lib.Toy;

namespace Telstra.ToyRobot.Lib.Surface;

/// <summary>
/// This is the implementation of a surface that the robot can move on and look at.
/// </summary>
public class TableTop : IViewableSurface
{
    private readonly int height;
    private readonly int width;

    public TableTop(int height, int width) => (this.height, this.width) = (height, width);

    /// <summary>
    /// The robot can look at this location to see if is somewhere that can be moved to.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool IsValidLocation(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}
