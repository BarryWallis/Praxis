using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BingoSimulator.Model;
using System.Collections.Generic;

namespace BingoSimulatorUnitTests
{
    [TestClass]
    public class BingoSimulatorTest
    {
        [TestMethod]
        public void VerticalBingo()
        {
            BingoCard card = new BingoCard();
            for (int column = 0; column < BingoCard.MaxColumns - 1; column++)
            {
                Assert.IsFalse(card.Mark(card.GetCard()[0, column].Number));
            }
            Assert.IsTrue(card.Mark(card.GetCard()[0, BingoCard.MaxColumns - 1].Number));
        }

        [TestMethod]
        public void HorizontalBingo()
        {
            BingoCard card = new BingoCard();
            for (int row = 0; row < BingoCard.MaxColumns - 1; row++)
            {
                Assert.IsFalse(card.Mark(card.GetCard()[row, 0].Number));
            }
            Assert.IsTrue(card.Mark(card.GetCard()[BingoCard.MaxRows - 1, 0].Number));
        }

        [TestMethod]
        public void TopLeftDiagonalBingo()
        {
            BingoCard card = new BingoCard();
            for (int n = 0; n < BingoCard.MaxColumns - 1; n++)
            {
                Assert.IsFalse(card.Mark(card.GetCard()[n, n].Number));
            }
            Assert.IsTrue(card.Mark(card.GetCard()[BingoCard.MaxRows - 1, BingoCard.MaxRows - 1].Number));
        }

        [TestMethod]
        public void TopRightDiagonalBingo()
        {
            BingoCard card = new BingoCard();
            for (int n = 0; n < BingoCard.MaxColumns - 1; n++)
            {
                Assert.IsFalse(card.Mark(card.GetCard()[n, BingoCard.MaxColumns - n - 1].Number));
            }
            Assert.IsTrue(card.Mark(card.GetCard()[BingoCard.MaxRows - 1, 0].Number));
        }

        [TestMethod]
        public void PlayGameWithOneCard()
        {
            List<BingoCard> cards = new List<BingoCard>() { new BingoCard() };
            int ballsCalled = BingoManager.Instance.PlayGameWithCards(cards);
            Assert.IsTrue(ballsCalled >= 5 & ballsCalled <= 75);
        }

        [TestMethod]
        public void PlayGamesWithCards()
        {
            int AverageBallsCalled = BingoManager.Instance.PlayGamesWithCards(2, 2);
            Assert.IsTrue(AverageBallsCalled >= 5 & AverageBallsCalled <= 75);
        }
    }
}