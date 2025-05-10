namespace LibrarySystem.xUnit.Methods
{
    public class Library
    {
        public Book[] Books { get; set; }
        public double MinRating { get; set; }
        public double MaxRating { get; set; }
        public double ExclusionPercentage { get; set; }

        public Library(int numberOfBooks, double minRating, double maxRating, double exclusionPercentage)
        {
            if(numberOfBooks < 1 || numberOfBooks > 100)
            {
                throw new ArgumentException("Некорректное количество книг.");
            }
            Books = new Book[numberOfBooks];

            if (minRating < 1 || minRating > 10)
            {
                throw new ArgumentException("Некорректное значение минимальной оценки.");
            }
            MinRating = minRating;

            if (maxRating < 1 || maxRating > 10)
            {
                throw new ArgumentException("Некорректное значение максимальной оценки.");
            }
            MaxRating = maxRating;

            if (exclusionPercentage < 0 || exclusionPercentage > 100)
            {
                throw new ArgumentException("Некорректное значение процента неучтенных книг.");
            }
            ExclusionPercentage = exclusionPercentage;
        }

        public double CalculateFinalRating()
        {
            double totalRating = 0;
            int countIncludedBooks = 0;

            foreach (var book in Books)
            {
                double finalScore = book.CalculateFinalScore();
                if (finalScore >= MinRating && finalScore <= MaxRating)
                {
                    totalRating += finalScore;
                    countIncludedBooks++;
                }
            }

            int booksToExclude = (int)(Books.Length * (ExclusionPercentage / 100));
            totalRating -= booksToExclude;

            return totalRating;
        }
    }
}
