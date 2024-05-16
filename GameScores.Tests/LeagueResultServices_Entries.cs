namespace GameScores.Tests;

using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class LeagueResultServices_Entries
{
    [Fact]
    public void GetNumberEntries_InvalidEntry_ReturnOne()
    {
        var mockingNumberEntries = new Mock<IEntryReader>();
        var loggerMock = new Mock<ILogger>();
        var scoreCalculatorMock = new Mock<IScoreCalculator>();
        mockingNumberEntries.Setup(m => m.GetNumberEntries()).Returns(0);
        LeagueResultsService service = new LeagueResultsService(loggerMock.Object, mockingNumberEntries.Object,scoreCalculatorMock.Object);
        Assert.True(service.CalculateScore()==1);
    }

    [Fact]
    public void GetNumberEntries_ValidEntry_ReturnZero()
    {
        var mockingNumberEntries = new Mock<IEntryReader>();
        var loggerMock = new Mock<ILogger>();
        var scoreCalculatorMock = new Mock<IScoreCalculator>();
        mockingNumberEntries.Setup(m => m.GetNumberEntries()).Returns(12);
        LeagueResultsService service = new LeagueResultsService(loggerMock.Object, mockingNumberEntries.Object, scoreCalculatorMock.Object);
        Assert.True(service.CalculateScore() == 0);
    }
}