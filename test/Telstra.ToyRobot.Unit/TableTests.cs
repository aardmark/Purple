using Telstra.ToyRobot.Lib.Surface;
using Xunit;

namespace Telstra.ToyRobot.Unit;

public class TableTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(5, 5)]
    [InlineData(0, 4)]
    [InlineData(3, 3)]
    public void TableCorrectlyReportsValidLocations(int x, int y)
    {
        var table = new TableTop(6,6);
        Assert.True(table.IsValidLocation(x, y));
    }

    [Theory]
    [InlineData(6, 0)]
    [InlineData(-1, 5)]
    [InlineData(3, 7)]
    public void TableCorrectlyReportsInvalidLocations(int x, int y)
    {
        var table = new TableTop(6, 6);
        Assert.False(table.IsValidLocation(x, y));
    }
}
