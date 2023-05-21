using System.Reflection;
using AoC2015;
using AoC.Common;
public class Program
{
    private static void Main(string[] args)
    {
        var year = GetYear();
        var exerciseTypes = Assembly.Load($"AoC{year}").GetTypes().Where(t =>
            t.GetInterfaces().Contains(typeof(IExercise)) &&
            t.Namespace == $"AoC{year}").ToList();

        for (int i = 1; i < 26; i++)
        {
            var exerciseType = exerciseTypes.Where(t => t.Name == $"Day{i}").FirstOrDefault();

            if (exerciseType == null
                || exerciseType.IsAbstract
                || exerciseType.GetConstructor(new[] { typeof(TextReader) }) == null)
            {
                break;
            }

            var filePath = $"./{year}/day/{i}/input.txt";


            using (var reader = new StreamReader(filePath))
            {
                if (Activator.CreateInstance(exerciseType, reader) is IExercise exercise)
                {
                    string partOneResult = exercise.SolvePart1();
                    string partTwoResult = exercise.SolvePart2();

                    Console.WriteLine($"Day {i}: {partOneResult} | {partTwoResult}");
                }
            }
        }
    }

    private static string GetYear()
    {
        var year = String.Empty;
        var firstYear = 2015;
        var lastYear = DateTime.Now.Month < 12 ? DateTime.Now.Year - 1 : DateTime.Now.Year;
        while (true)
        {
            Console.Write($"Choose a Year ({firstYear}-{lastYear}): ");
            year = Console.ReadLine();

            if (year != null && int.Parse(year) >= firstYear && int.Parse(year) <= lastYear)
            {
                break;
            }

            Console.WriteLine("Invalid year. Try again...");
        }

        return year;
    }
}
