using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Snake_and_Ladder.Services;
using Snake_and_Ladder.Services.Interfaces;
using System.Collections.Generic;

namespace Snake_and_Ladder_Tests
{
    public class DiceServiceTests
    {
        private IDiceService subject;

        [SetUp]
        public void Setup()
        {
            var logger = Mock.Of<ILogger<IDiceService>>();

            subject = new DiceService(logger);
        }

        [Test(Description = "Given the game is started. When the player rolls a die. Then the result should be between 1 - 6 inclusive")]
        public void MovesAreDeterminedByDiceRolls_UAT1()
        {
            List<int> dice = new List<int> { 1, 2, 3, 4, 5, 6 };

            CollectionAssert.Contains(dice, subject.Roll());
        }

    }
}