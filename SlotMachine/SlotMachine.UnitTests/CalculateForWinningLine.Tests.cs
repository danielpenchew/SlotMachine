using SlotMachine.Services;

namespace SlotMachine.UnitTests
{
    [TestClass]
    public class CheckForWinningLineTests
    {
        private SlotMachineService _sut = new SlotMachineService();
        [TestMethod]
        public void CheckForWinningLine_ReturnTrue_WithThreeMatchingSymbols()
        {
            // Arrange
            string firstSlot = "A";
            string secondSlot = "A";
            string thirdSlot = "A";

            bool expectedResult = true;

            // Act 
            bool actualResult = _sut.CheckForWinningLine(firstSlot, secondSlot, thirdSlot);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void CheckForWinningLine_ReturnTrue_WithTwoAsteriskAndASymbol()
        {
            // Arrange
            string firstSlot = "*";
            string secondSlot = "*";
            string thirdSlot = "A";

            bool expectedResult = true;

            // Act 
            bool actualResult = _sut.CheckForWinningLine(firstSlot, secondSlot, thirdSlot);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CheckForWinningLine_ReturnTrue_WithTwoMatchingSymbolsAndAsterisk()
        {
            // Arrange
            string firstSlot = "A";
            string secondSlot = "A";
            string thirdSlot = "*";

            bool expectedResult = true;

            // Act 
            bool actualResult = _sut.CheckForWinningLine(firstSlot, secondSlot, thirdSlot);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CheckForWinningLine_ReturnFalse_WithThreeDifferentSymbols()
        {
            // Arrange
            string firstSlot = "A";
            string secondSlot = "B";
            string thirdSlot = "P";

            bool expectedResult = false;

            // Act 
            bool actualResult = _sut.CheckForWinningLine(firstSlot, secondSlot, thirdSlot);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CheckForWinningLine_ReturnFalse_WithAsteriskAndTwoDifferentSymbols()
        {
            // Arrange
            string firstSlot = "*";
            string secondSlot = "B";
            string thirdSlot = "P";

            bool expectedResult = false;

            // Act 
            bool actualResult = _sut.CheckForWinningLine(firstSlot, secondSlot, thirdSlot);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}