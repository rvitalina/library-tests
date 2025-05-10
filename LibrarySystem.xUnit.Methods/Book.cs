using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.xUnit.Methods
{
    public class Book
    {
        public int ReviewCount { get; set; }
        public double Rating { get; set; }
        public double BonusPoints { get; set; }

        public Book(int reviewCount, double rating, double bonusPoints)
        {
            if (reviewCount <= 0)
            {
                throw new ArgumentException("Некорректное число отзывов.");
            }
            ReviewCount = reviewCount;

            if (rating < 1 || rating > 10)
            {
                throw new ArgumentException("Некорректное значение оценки.");
            }
            Rating = rating;

            if (bonusPoints <= 0)
            {
                throw new ArgumentException("Некорректное количество бонусных баллов.");
            }
            BonusPoints = bonusPoints;
        }

        public double CalculateFinalScore()
        {
            return (Rating / ReviewCount) + BonusPoints;
        }

    }
}
