using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trial_2
{
    class Film
    {
        private string Name { get; set; }
        private string Director { get; set; }
        private int Year { get; set; }
        private string Genre { get; set; }
        public List<double> Ratings { get; set; }

        public Film()
        {
            Ratings = new List<double>();
        }

        public Film(string name, string director, int year, string genre, List<double> ratings)
        {
            Name = name;
            Director = director;
            Year = year;
            Genre = genre;
            Ratings = ratings;
        }

        ~Film()
        {
            
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Director: {Director}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Genre: {Genre}");
        }

        public void CalculateAverageRating()
        {
            if (Ratings.Count > 0)
            {
                double averageRating = Ratings.Average();
                Console.WriteLine($"Rating: {averageRating:F2}");
            }
            else
            {
                Console.WriteLine("No ratings available.");
            }
        }
    }

    class Rating : Film
    {
        public Rating(string name, string director, int year, string genre, List<double> ratings) : base(name, director, year, genre, ratings)
        {
        }

        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Ratings:");
            foreach (var rating in Ratings)
            {
                Console.WriteLine($"{rating:F2}");
            }
        }

        public new void CalculateAverageRating()
        {
            base.CalculateAverageRating();
        }
    }

    interface IBoxOffice
    {
        void PrintEarnings();
    }

    class BoxOffice : IBoxOffice
    {
        private List<double> AllEarnings { get; set; }

        public BoxOffice()
        {
            AllEarnings = new List<double>();
        }

        public void PrintEarnings()
        {
            Console.WriteLine("Earnings:");
            foreach (var earnings in AllEarnings)
            {
                Console.WriteLine($"{earnings:C2}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please insert Film Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Please insert Film Director:");
                string director = Console.ReadLine();

                Console.WriteLine("Please insert film year:");
                int year;
                while (!int.TryParse(Console.ReadLine(), out year))
                {
                    Console.WriteLine("Invalid input. Please enter a valid year:");
                }

                Console.WriteLine("Please insert film genre:");
                string genre = Console.ReadLine();

                Console.WriteLine("Please start inserting film ratings between 0 and 5. To stop, please insert \"/\":");

                List<double> ratings = new List<double>();
                bool stop = false;
                while (!stop)
                {
                    string input = Console.ReadLine();
                    if (input == "/")
                    {
                        stop = true;
                        continue;
                    }

                    if (double.TryParse(input, out double rating) && rating >= 0 && rating <= 5)
                    {
                        ratings.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("You have entered an incorrect rating. Allowed rating should be between 0 and 5!");
                    }
                }

                Rating film = new Rating(name, director, year, genre, ratings);

                Console.WriteLine("\nOutput:");
                film.PrintInfo();
                film.CalculateAverageRating();

                Console.WriteLine("Do you want to input another film? (yes/no)");
                string inputAnother = Console.ReadLine();
                if (inputAnother.ToLower() != "yes")
                {
                    break; 
                }
            }
        }
    }
}
