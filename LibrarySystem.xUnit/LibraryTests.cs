using LibrarySystem.xUnit.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibrarySystem.xUnit
{
    public class LibraryTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(101)]
        public void LibraryConstructor_InvalidNumberOfBooks_ShouldThrowArgumentException(int numberOfBooks)
        {
            // Arrange
            double minRating = 3.5;
            double maxRating = 8;
            double exclusionPercentage = 20;

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
                new Library(numberOfBooks, minRating, maxRating, exclusionPercentage));

            // Assert
            Assert.Equal("Некорректное количество книг.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(11)]
        public void LibraryConstructor_InvalidMinRating_ShouldThrowArgumentException(double minRating)
        {
            // Arrange
            int numberOfBooks = 11;
            double maxRating = 9;
            double exclusionPercentage = 30;

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
                new Library(numberOfBooks, minRating, maxRating, exclusionPercentage));

            // Assert
            Assert.Equal("Некорректное значение минимальной оценки.", exception.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(11)]
        public void LibraryConstructor_InvalidMaxRating_ShouldThrowArgumentException(double maxRating)
        {
            // Arrange
            int numberOfBooks = 12;
            double minRating = 3;
            double exclusionPercentage = 40;

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
                new Library(numberOfBooks, minRating, maxRating, exclusionPercentage));

            // Assert
            Assert.Equal("Некорректное значение максимальной оценки.", exception.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void LibraryConstructor_InvalidExclusionPercentage_ShouldThrowArgumentException(double exclusionPercentage)
        {
            // Arrange
            double minRating = 4;
            double maxRating = 9;
            int numberOfBooks = 50;

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
                new Library(numberOfBooks, minRating, maxRating, exclusionPercentage));

            // Assert
            Assert.Equal("Некорректное значение процента неучтенных книг.", exception.Message);
        }

        [Theory]
        [InlineData(1, 5, 8, 40, 3, 6, 2, 0)]
        [InlineData(1, 5, 8, 50, 5, 7, 3, 0)]
        [InlineData(1, 6, 9, 30, 3, 5, 6, 7.67)]
        public void CalculateFinalRating_VariousParameters_ShouldReturnExpectedValue(int numberOfBooks, double minRating, double maxRating, double exclusionPercentage, int reviewCount, double rating, double bonusPoints, double expectedFinalRating)
        {
            // Arrange
            var library = new Library(numberOfBooks, minRating, maxRating, exclusionPercentage);
            for (int i = 0; i < numberOfBooks; i++)
            {
                var book = new Book(reviewCount, rating, bonusPoints);
                
                library.Books[i] = book;
            }

            // Act
            double actualFinalRating = library.CalculateFinalRating();

            // Assert
            Assert.Equal(expectedFinalRating, actualFinalRating, 2); // Comparing with 2 decimal places
        }

    }
}
