using System.Text.RegularExpressions;
using Telstra.ToyRobot.Lib.Toy;

namespace Telstra.ToyRobot.Lib.Simulator;

/// <summary>
/// This is the container for the simulation. It parses input and commands the robot.
/// </summary>
public class Simulator
{
    readonly Robot robot;
    private static readonly string placeCommandPattern = "^PLACE ([0-9]+),([0-9]+)(?:,(NORTH|SOUTH|EAST|WEST))?";

    public Simulator(Robot robot) => this.robot = robot;

    public string ProcessCommand(string command)
    {
        if (string.IsNullOrEmpty(command)) return string.Empty;
        switch (command)
        {
            case "MOVE": robot.Move(); return string.Empty; 
            case "LEFT": robot.TurnLeft(); return string.Empty; 
            case "RIGHT": robot.TurnRight(); return string.Empty;
            case "REPORT": return robot.Report();
        }
        var match = Regex.Match(command, placeCommandPattern);
        if (match.Success && match.Groups.Count >= 3)
        {
            var x = Convert.ToInt32(match.Groups[1].Value);
            var y = Convert.ToInt32(match.Groups[2].Value);
            var direction = match.Groups.Count == 4
                ? match.Groups[3].Value
                : string.Empty;
            robot.Place(x, y, direction);
        }
        return string.Empty;
    }
}
