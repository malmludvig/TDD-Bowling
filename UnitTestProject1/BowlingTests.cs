using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTestProject1
{

    [TestClass]

        public class BowlingGameTest
        {
            private BowlingGame bowlingGame;

            public BowlingGameTest()
            {
                bowlingGame = new BowlingGame();
            }

            private void rollManyRolls(int rolls, int pins)
            {
                for (int i = 0; i < rolls; i++)
                {
                    bowlingGame.Roll(pins);
                }
            }

            private void rollASpare()
            {
                bowlingGame.Roll(2);
                bowlingGame.Roll(8);
            }


        [TestMethod]

        public void Game_StartAGameWith4People_ReturnTrue()
        {

            var newGame = new BowlingGameWithPeople();

            newGame.StartGame(4);

            var actual = newGame.PersonList.Count;

            Assert.AreEqual(actual, 4);

        }

        [TestMethod]
        public void Game_ActivePlayer_ReturnTrue()
        {
            var newGame = new BowlingGameWithPeople();

            var newPerson = new Person();
            newGame.PersonList.Add(newPerson);

            newGame.CurrentPlayer = newPerson;

            var actual = newPerson;

            Assert.AreEqual(actual, newGame.CurrentPlayer);

        }

        [TestMethod]
        public void Game_NexTurnActivePlayer_ReturnTrue()
        {

            var newGame = new BowlingGameWithPeople();

            var myList = newGame.StartGame(2);

            bowlingGame.Roll(4);
            bowlingGame.Roll(2);
            int score1 = bowlingGame.Score();
            newGame.CurrentPlayer.Score = score1;

            newGame.CurrentPlayer = myList[1];

            bowlingGame.Roll(3);
            bowlingGame.Roll(5);
            int score2 = bowlingGame.Score() - score1;
            newGame.CurrentPlayer.Score = score2;

            var actual = myList[0].Score + myList[1].Score;

            Assert.AreEqual(14, actual);
        }

        [TestMethod]
        public void Game_GetNameFromPlayer_ReturnTrue()
        {
            var newGame = new BowlingGameWithPeople();

            var myList = newGame.StartGame(2);

            var actual = myList[0].Name;

            Assert.AreEqual("Peter", actual);
        }

        [TestMethod]
        public void Game_GetScoreFromPlayer_ReturnTrue()
        {
            var newGame = new BowlingGameWithPeople();

            var myList = newGame.StartGame(2);

            var actual = myList[0].Score;

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
            public void Score_OnlyRollGutterballsFor10Frames_Returns0()
            {
                rollManyRolls(20, 0);
                Assert.AreEqual(0, bowlingGame.Score());
            }

            [TestMethod]
            public void Score_1PointGame_Returns20()
            {
                rollManyRolls(20, 1);
                Assert.AreEqual(20, bowlingGame.Score());
            }

            [TestMethod]
            public void Score_RollBall_OneSpare_Returns18()
            {
                rollASpare();
                bowlingGame.Roll(4);
                rollManyRolls(17, 0);
                Assert.AreEqual(18, bowlingGame.Score());
            }

            [TestMethod]
            public void Score_RollBall_Strike_Returns28()
            {
                bowlingGame.Roll(10);
                bowlingGame.Roll(4);
                bowlingGame.Roll(5);
                rollManyRolls(17, 0);
                Assert.AreEqual(28, bowlingGame.Score());
            }

            [TestMethod]
            public void Score_Rollball_PerfectGame_Returns300()
            {
                rollManyRolls(12, 10);
                Assert.AreEqual(300, bowlingGame.Score());
            }

            [TestMethod]
            public void Score_Rollball_TestRandomGameNoExtraRoll_Returns131()
            {
                bowlingGame.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
                Assert.AreEqual(131, bowlingGame.Score());
            }

            [TestMethod]
            public void Score_Rollball_TestRandomGameWithSpareThenStrikeAtEnd_Returns143()
            {
                bowlingGame.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
                Assert.AreEqual(143, bowlingGame.Score());
            }

            [TestMethod]
            public void Score_Rollball_TestRandomGameWithThreeStrikesAtEnd_Returns163()
            {
                bowlingGame.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
                Assert.AreEqual(163, bowlingGame.Score());
            }

        }
}






