using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Snake_and_Ladder.Domain;
using Snake_and_Ladder.Services;
using Snake_and_Ladder.Services.Interfaces;
using System;
using System.Linq.Expressions;

namespace Snake_and_Ladder_Tests
{
    public class ScoreBoardTests
    {
        private Mock<IBoardEntityProvider> mockEntityProvider;
        private Mock<IDiceService> mockDiceService;
        private Mock<IBoardProvider> mockBoardProvider;

        private Player player;
        private IScoreBoard subject;

        [SetUp]
        public void Setup()
        {
            var logger = Mock.Of<ILogger<IScoreBoard>>();
            mockEntityProvider = new Mock<IBoardEntityProvider>();
            mockEntityProvider.Setup(x => x.FindSingle(It.IsAny<Expression<Func<BoardEntity, bool>>>())).Returns(() => null);

            mockBoardProvider = new Mock<IBoardProvider>();
            mockDiceService = new Mock<IDiceService>();

            player = new Player(1, "Player1");
            subject = new ScoreBoard(logger);
        }

        [Test(Description = "Given the game is started.When the token is placed on the board. Then the token is on square 1")]
        public void TokenCanMoveAcrosstheBoard_UAT1()
        {
            subject.StartPlayer(player.Id);
            Assert.IsTrue(subject.GetPosition(player.Id) == 1);
        }

        [Test(Description = "Given the token is on square 1. When the token is moved 3 spaces. Then the token is on square 4")]
        public void TokenCanMoveAcrosstheBoard_UAT2()
        {
            mockDiceService.Setup(x => x.Roll()).Returns(3);
            subject.StartPlayer(player.Id);
            subject.SetPosition(player.Id, mockDiceService.Object.Roll());
            Assert.IsTrue(subject.GetPosition(player.Id) == 4);
        }

        [Test(Description = "Given the token is on square 1. When the token is moved 3 spaces. And then it is moved 4 spaces. Then the token is on square 8")]
        public void TokenCanMoveAcrosstheBoard_UAT3()
        {
            subject.StartPlayer(player.Id);
            subject.SetPosition(player.Id, 3);
            subject.SetPosition(player.Id, 4);
            Assert.IsTrue(subject.GetPosition(player.Id) == 8);
        }

        [Test(Description = "Given the token is on square 97. When the token is moved 3 spaces. Then the token is on square 100. And the player has won the game")]
        public void PlayerCanWintheGame_UAT1()
        {
            subject.StartPlayer(player.Id);
            subject.SetPosition(player.Id, 96);
            subject.SetPosition(player.Id, 3);
            Assert.IsTrue(subject.IsWinner(player.Id));
        }

        [Test(Description = "Given the token is on square 97. When the token is moved 4 spaces. Then the token is on square 97. And the player has not won the game")]
        public void PlayerCanWintheGame_UAT2()
        {
            subject.StartPlayer(player.Id);
            subject.SetPosition(player.Id, 96);
            subject.SetPosition(player.Id, 4);
            Assert.IsFalse(subject.IsWinner(player.Id));
        }

        [Test(Description = "Given the player rolls a 4. When they move their token. Then the token should move 4 spaces")]
        public void MovesAreDeterminedByDiceRolls_UAT2()
        {
            subject.StartPlayer(player.Id);
            mockDiceService.Setup(x => x.Roll()).Returns(4);
            subject.SetPosition(player.Id, mockDiceService.Object.Roll());
            Assert.IsTrue(subject.GetPosition(player.Id) == 5);
        }

    }
}
