using LibrarySystem.xUnit.Methods;
using System.Xml;

namespace LibrarySystem.xUnit
{
    public class BookTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void BookConstructor_InvalidReviewCount_ShouldThrowArgumentException(int reviewCount)
        {
            // Arrange
            double rating = 3.5;
            double bonusPoints = 3;

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
                new Book(reviewCount, rating, bonusPoints));

            // Assert
            Assert.Equal("Некорректное число отзывов.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(11)]
        public void BookConstructor_InvalidRating_ShouldThrowArgumentException(double rating)
        {
            // Arrange
            int reviewCount = 5;
            double bonusPoints = 3;

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
                new Book(reviewCount, rating, bonusPoints));

            // Assert
            Assert.Equal("Некорректное значение оценки.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void BookConstructor_InvalidBonusPoints_ShouldThrowArgumentException(double bonusPoints)
        {
            // Arrange
            double rating = 3.5;
            int reviewCount = 5;
            
            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
                new Book(reviewCount, rating, bonusPoints));

            // Assert
            Assert.Equal("Некорректное количество бонусных баллов.", exception.Message);
        }

        [Theory]
        [InlineData(1, 10, 5, 15)]    // 10 / 1 + 5 = 15
        [InlineData(5, 8, 2, 3.6)]     // 8 / 5 + 2 = 3.6
        [InlineData(2, 6, 3, 6)]       // 6 / 2 + 3 = 6
        [InlineData(10, 5, 1, 1.5)]    // 5 / 10 + 1 = 1.5
        [InlineData(3, 9, 0.5, 3.5)]   // 9 / 3 + 0.5 = 3.5
        public void CalculateFinalScore_VariousParameters_ShouldReturnExpectedResult(int reviewCount, double rating, double bonusPoints, double expectedScore)
        {
            // Arrange
            var book = new Book(reviewCount, rating, bonusPoints);

            // Act
            var actualScore = book.CalculateFinalScore();

            // Assert
            Assert.Equal(expectedScore, actualScore, 2); // Сравнение с точностью до 2 знаков после запятой
        }
    }
}