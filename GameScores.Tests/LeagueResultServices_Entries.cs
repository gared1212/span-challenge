namespace GameScores.Tests;

using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using GameScores.Infra;
using GameScores.Models;
using GameScores.Services;

public class LeagueResultServices_Entries
{
    [Fact]
    public void GetNumberEntries_InvalidEntry_ReturnOne()
    {
        var mockingNumberEntries = new Mock<IEntryReader>();
        var loggerMock = new Mock<ILogger>();
        var scoreCalculatorMock = new Mock<IScoreCalculator>();
        mockingNumberEntries.Setup(m => m.GetNumberEntries()).Returns(0);
        LeagueResultsService service = new LeagueResultsService(loggerMock.Object, mockingNumberEntries.Object, scoreCalculatorMock.Object, new OutputWriterConsole());
        Assert.True(service.CalculateScore() == 1);
    }

    [Fact]
    public void GetNumberEntries_ValidEntry_ReturnZero()
    {
        var mockingNumberEntries = new Mock<IEntryReader>();
        var loggerMock = new Mock<ILogger>();        
        var scoreCalculatorMock = new Mock<IScoreCalculator>();
        var mockingOutputWriter = new Mock<IOutputWriter>();
        mockingNumberEntries.Setup(m => m.GetNumberEntries()).Returns(12);
        var matches = new List<Models.Match>();
        matches.Add(new Models.Match("Lions", 1, "Atletico san Pancho", 1));
        mockingNumberEntries.Setup(m => m.GetMatches(12)).Returns(matches);
        mockingOutputWriter.Setup(x => x.PublishResults(new SortedSet<(string name, int points)>())).Verifiable();
        LeagueResultsService service = new LeagueResultsService(loggerMock.Object, mockingNumberEntries.Object, scoreCalculatorMock.Object, mockingOutputWriter.Object);
        Assert.True(service.CalculateScore() == 0);
    }
}