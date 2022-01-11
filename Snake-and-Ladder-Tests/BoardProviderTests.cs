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
    public class BoardProviderTests
    {
        private Mock<IBoardEntityProvider> mockEntityProvider;
        private Mock<IDiceService> mockDiceService;

        private IBoardProvider subject;

        [SetUp]
        public void Setup()
        {
            var logger = Mock.Of<ILogger<IBoardProvider>>();
            mockEntityProvider = new Mock<IBoardEntityProvider>();
            mockEntityProvider.Setup(x => x.FindSingle(It.IsAny<Expression<Func<BoardEntity, bool>>>())).Returns(() => null);

            mockDiceService = new Mock<IDiceService>();

            subject = new DefaultBoardProvider(logger, mockEntityProvider.Object);
        }

        [Test(Description = "Given the game is started.When the token is placed on the board. Then the token is on square 1")]
        public void TokenCanMoveAcrosstheBoard_UAT1()
        {
            var player = new Player(1, "Player1");
            Assert.IsTrue(player.Position == 1);
        }

        [Test(Description = "Given the token is on square 1. When the token is moved 3 spaces. Then the token is on square 4")]
        public void TokenCanMoveAcrosstheBoard_UAT2()
        {
            var player = new Player(1, "Player1");
            subject.Move(player, 3);
            Assert.IsTrue(player.Position == 4);
        }

        [Test(Description = "Given the token is on square 1. When the token is moved 3 spaces. And then it is moved 4 spaces. Then the token is on square 8")]
        public void TokenCanMoveAcrosstheBoard_UAT3()
        {
            var player = new Player(1, "Player1");
            subject.Move(player, 3);
            subject.Move(player, 4);
            Assert.IsTrue(player.Position == 8);
        }

        [Test(Description = "Given the token is on square 97. When the token is moved 3 spaces. Then the token is on square 100. And the player has won the game")]
        public void PlayerCanWintheGame_UAT1()
        {
            var player = new Player(1, "Player1");
            subject.Move(player, 96);
            subject.Move(player, 3);
            Assert.IsTrue(player.Position == 100);
        }

        [Test(Description = "Given the token is on square 97. When the token is moved 4 spaces. Then the token is on square 100. And the player has not won the game")]
        public void PlayerCanWintheGame_UAT2()
        {
            var player = new Player(1, "Player1");
            subject.Move(player, 96);
            subject.Move(player, 4);
            Assert.IsFalse(player.Position == 100);
        }

        [Test(Description = "Given the player rolls a 4. When they move their token. Then the token should move 4 spaces")]
        public void MovesAreDeterminedByDiceRolls_UAT2()
        {
            var player = new Player(1, "Player1");
            mockDiceService.Setup(x => x.Roll()).Returns(4);
            subject.Move(player, mockDiceService.Object.Roll());
            Assert.IsTrue(player.Position == 5);
        }

    }
}
