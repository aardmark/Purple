using Telstra.ToyRobot.Lib.Simulator;
using Telstra.ToyRobot.Lib.Surface;
using Telstra.ToyRobot.Lib.Toy;

// Manually wire up dependency injection.
// The simulator depends on having a robot, the robot depends on having something to move on and look at.
var simulator = new Simulator(new Robot(new TableTop(6, 6)));

Console.Write("> ");
var command = Console.ReadLine();

while(!string.IsNullOrEmpty(command))
{
    var result = simulator.ProcessCommand(command);
    if (!string.IsNullOrEmpty(result))
    {
        Console.WriteLine(result);  
    }
    Console.Write("> ");
    command = Console.ReadLine();   
}
