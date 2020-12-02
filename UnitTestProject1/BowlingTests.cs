using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System.ComponentModel;

namespace UnitTestProject1
{
    [TestClass]
    public class BowlingTests
    {

        [TestMethod]

        public void Score_RollBall_Spare()
        {

            //Arrange
            var NewFrame = new Round();

            NewFrame.Roll(8);
            NewFrame.Roll(2);

            //Act
            var actual = NewFrame.Score();

            //Assert
            Assert.AreEqual(actual, 10);
        }

        [TestMethod]

        public void Score_RollBall_Spare10InSecondRoll()
        {

            //Arrange
            var NewFrame = new Round();

            NewFrame.Roll(0);
            NewFrame.Roll(10);

            //Act
            var actual = NewFrame.Score();

            //Assert
            Assert.AreEqual(actual, 10);
        }

        [TestMethod]

        public void Score_RollBall_Strike_Returns10()
        {

            //Arrange
            var NewFrame = new Round();

            NewFrame.Roll(10);

            //Act
            var actual = NewFrame.Score();

            //Assert
            Assert.AreEqual(actual, 10);
        }

        [TestMethod]

        public void Score_RollBallTwoThrows_Returns3()
        {

            //Arrange
            var NewFrame = new Round();

            NewFrame.Roll(1);
            NewFrame.Roll(2);

            //Act
            var actual = NewFrame.Score();

            //Assert
            Assert.AreEqual(actual, 3);
        }

        public void Score_RollBall_Returns1()
        {

            //Arrange
            var NewFrame = new Round();

            NewFrame.Roll(1);

            //Act
            var actual = NewFrame.Score();

            //Assert
            Assert.AreEqual(actual, 1);
        }

        [TestMethod]

        public void Score_RollGutterball_Returns0()
        {

            //Arrange
            var GutterBall = new Round();

            GutterBall.Roll(0);

            //Act
            var actual = GutterBall.Score();

            //Assert
            Assert.AreEqual(actual, 0);
        }

        [TestMethod]

        public void Score_OnlyRollGutterballsFor10Frames_Returns0()
        {

            //Arrange
            var GutterBall = new Round();

            for (int frame = 0; frame <= 20; frame++)
                GutterBall.Roll(0);

            //Act
            var actual = GutterBall.Score();

            //Assert
            Assert.AreEqual(actual, 0);
        }
    }
}
