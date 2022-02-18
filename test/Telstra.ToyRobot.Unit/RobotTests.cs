using Moq;
using Telstra.ToyRobot.Lib.Toy;
using Xunit;

namespace Telstra.ToyRobot.Unit;

public class RobotTests
{
    readonly IViewableSurface tableTop;

    public RobotTests()
    {
        var surface = new Mock<IViewableSurface>();
        surface.Setup(x => x.IsValidLocation(It.IsInRange(0, 5, Range.Inclusive), It.IsInRange(0, 5, Range.Inclusive))).Returns(true);
        surface.Setup(x => x.IsValidLocation(It.Is<int>(x => x < 0 || x > 5), It.Is<int>(y => y < 0 || y > 5))).Returns(false);
        tableTop = surface.Object;
    }

    [Fact]
    public void RobotIsPlacedInTheCorrectPlaceWithTheCorrectDirection()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "NORTH");
        Assert.Equal("0,0,NORTH", robot.Report());
    }

    [Fact]
    public void RobotMovesToAValidLocation()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "NORTH");
        robot.Move();
        Assert.Equal("0,1,NORTH", robot.Report());
    }

    [Fact]
    public void RobotDiscardsCommandsIfNotPlacedFirst()
    {
        var robot = new Robot(tableTop);
        robot.Move();
        Assert.Equal(string.Empty, robot.Report());
        robot.TurnLeft();
        Assert.Equal(string.Empty, robot.Report());
        robot.TurnRight();
        Assert.Equal(string.Empty, robot.Report());
        robot.Place(1, 1);
        Assert.Equal(string.Empty, robot.Report());
    }

    [Fact]
    public void RobotTurnsRight()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "NORTH");
        robot.TurnRight();
        Assert.Equal("0,0,EAST", robot.Report());
        robot.TurnRight();
        Assert.Equal("0,0,SOUTH", robot.Report());
        robot.TurnRight();
        Assert.Equal("0,0,WEST", robot.Report());
        robot.TurnRight();
        Assert.Equal("0,0,NORTH", robot.Report());
    }

    [Fact]
    public void RobotTurnsLeft()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "NORTH");
        robot.TurnLeft();
        Assert.Equal("0,0,WEST", robot.Report());
        robot.TurnLeft();
        Assert.Equal("0,0,SOUTH", robot.Report());
        robot.TurnLeft();
        Assert.Equal("0,0,EAST", robot.Report());
        robot.TurnLeft();
        Assert.Equal("0,0,NORTH", robot.Report());
    }

    [Fact]
    public void RobotCanBePlacedElsewhere()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "NORTH");
        Assert.Equal("0,0,NORTH", robot.Report());
        robot.Place(3, 2, "WEST");
        Assert.Equal("3,2,WEST", robot.Report());
        robot.Place(5, 1, "SOUTH");
        Assert.Equal("5,1,SOUTH", robot.Report());
        robot.Place(5, 1, "EAST");
        Assert.Equal("5,1,EAST", robot.Report());
    }

    [Fact]
    public void RobotCanBePlacedElsewhereAndMaintainDirection()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "NORTH");
        Assert.Equal("0,0,NORTH", robot.Report());
        robot.Place(3, 2);
        Assert.Equal("3,2,NORTH", robot.Report());
    }

    [Fact]
    public void RobotCannotBePlacedOffTheSurface()
    {
        var robot = new Robot(tableTop);
        robot.Place(-10, 0, "NORTH");
        Assert.Equal(string.Empty, robot.Report());
        robot.Place(3, 6);
        Assert.Equal(string.Empty, robot.Report());
    }

    [Fact]
    public void RobotCannotBeMovedOffTheSurface()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "SOUTH");
        Assert.Equal("0,0,SOUTH", robot.Report());
        robot.Move();
        Assert.Equal("0,0,SOUTH", robot.Report());

        robot.Place(0, 0, "WEST");
        Assert.Equal("0,0,WEST", robot.Report());
        robot.Move();
        Assert.Equal("0,0,WEST", robot.Report());

        robot.Place(5, 5, "NORTH");
        Assert.Equal("5,5,NORTH", robot.Report());
        robot.Move();
        Assert.Equal("5,5,NORTH", robot.Report());

        robot.Place(5, 5, "EAST");
        Assert.Equal("5,5,EAST", robot.Report());
        robot.Move();
        Assert.Equal("5,5,EAST", robot.Report());
    }

    [Fact]
    public void RobotMovesNorth()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "NORTH");
        Assert.Equal("0,0,NORTH", robot.Report());
        robot.Move();
        Assert.Equal("0,1,NORTH", robot.Report());
    }

    [Fact]
    public void RobotMovesSouth()
    {
        var robot = new Robot(tableTop);
        robot.Place(5, 5, "SOUTH");
        Assert.Equal("5,5,SOUTH", robot.Report());
        robot.Move();
        Assert.Equal("5,4,SOUTH", robot.Report());
    }

    [Fact]
    public void RobotMovesEast()
    {
        var robot = new Robot(tableTop);
        robot.Place(0, 0, "EAST");
        Assert.Equal("0,0,EAST", robot.Report());
        robot.Move();
        Assert.Equal("1,0,EAST", robot.Report());
    }

    [Fact]
    public void RobotMovesWest()
    {
        var robot = new Robot(tableTop);
        robot.Place(5, 5, "WEST");
        Assert.Equal("5,5,WEST", robot.Report());
        robot.Move();
        Assert.Equal("4,5,WEST", robot.Report());
    }
}
