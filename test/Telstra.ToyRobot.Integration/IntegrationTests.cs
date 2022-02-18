using Telstra.ToyRobot.Lib.Simulator;
using Telstra.ToyRobot.Lib.Surface;
using Telstra.ToyRobot.Lib.Toy;
using Xunit;

namespace Telstra.ToyRobot.Integration;
public class IntegrationTests
{
    private static Simulator CreateSimulation()
    {
        return new Simulator(new Robot(new TableTop(6, 6)));
    }


    [Fact]
    public void Example1()
    {
        var simulator = CreateSimulation();
        simulator.ProcessCommand("PLACE 0,0,NORTH");
        simulator.ProcessCommand("MOVE");
        Assert.Equal("0,1,NORTH", simulator.ProcessCommand("REPORT"));
    }

    [Fact]
    public void Example2()
    {
        var simulator = CreateSimulation();
        simulator.ProcessCommand("PLACE 0,0,NORTH");
        simulator.ProcessCommand("LEFT");
        Assert.Equal("0,0,WEST", simulator.ProcessCommand("REPORT"));
    }

    [Fact]
    public void Example3()
    {
        var simulator = CreateSimulation();
        simulator.ProcessCommand("PLACE 1,2,EAST");
        simulator.ProcessCommand("MOVE");
        simulator.ProcessCommand("MOVE");
        simulator.ProcessCommand("LEFT");
        simulator.ProcessCommand("MOVE");
        Assert.Equal("3,3,NORTH", simulator.ProcessCommand("REPORT"));
    }

    [Fact]
    public void Example4()
    {
        var simulator = CreateSimulation();
        simulator.ProcessCommand("PLACE 1,2,EAST");
        simulator.ProcessCommand("MOVE");
        simulator.ProcessCommand("LEFT");
        simulator.ProcessCommand("MOVE");
        simulator.ProcessCommand("PLACE 3,1");
        simulator.ProcessCommand("MOVE");
        Assert.Equal("3,2,NORTH", simulator.ProcessCommand("REPORT"));
    }
}
