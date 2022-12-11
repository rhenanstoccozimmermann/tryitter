using FluentAssertions;
using Moq;
using tryitter.Controllers;
using tryitter.Service;
using tryitter.Models;

namespace tryitter.Test;

public class ControllerTest
{
    [Theory(DisplayName = "Deve testar se AddAccount adiciona uma pessoa ao banco de dados.")]
    [MemberData(nameof(DataTestAddAccount))]
    public void TestTestAddPlayer(Account account)
    {
        var mockService = new Mock<IAccountService>();
        mockService.Setup(c => c.ReadLine()).Returns(name);
    //     var database = new TrybeGamesDatabase();
    //     var controller = new TrybeGamesController(database, mockConsole.Object);

    //     controller.AddPlayer();

    //     controller.database.Players[0].Should().BeEquivalentTo(expected);
    // }
    // public static TheoryData<string, Player> DataTestAddAccount => new TheoryData<string, Player>
    // {
    //     {
    //         "IngridProPlayer",
    //         new Player()
    //         {
    //             Name = "IngridProPlayer",
    //             Id = 1 
    //         }
    //     }
    };
}