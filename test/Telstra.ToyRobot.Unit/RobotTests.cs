using Telstra.ToyRobot.Lib;
using Xunit;

namespace Telstra.ToyRobot.Unit;

public class RobotTests
{
    [Fact]
    public void ARobotIsARobot()
    {
        var robot = new Robot();
        Assert.True(robot is Robot);
    }
}