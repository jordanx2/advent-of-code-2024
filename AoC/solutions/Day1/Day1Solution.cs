using System.IO;

namespace Day1;
class Day1Solution 
{
  static void Main(string[] args)
  {
    try 
    {
      string[] lines = File.ReadAllLines("/Users/jordanmurray/Workspaces/advent-of-code/AoC/res/day1.txt");
      List<int> element1 = new List<int>();
      List<int> element2 = new List<int>();

      foreach (var line in lines)
      {
        var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        element1.Add(int.Parse(numbers[0]));
        element2.Add(int.Parse(numbers[1]));
      }

      element1.Sort();
      element2.Sort();

      int partOneTotal = element1.Zip(element2, (x, y) => Math.Abs(x - y)).ToArray().Sum();
      var rightCount = element2.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
      int partTwoTotal = element1.Sum(x => rightCount.GetValueOrDefault(x, 0) * x);
        
      Console.WriteLine("Part one: " + partOneTotal);
      Console.WriteLine("Part two: " + partTwoTotal);

    } catch(Exception e)
    {
      Console.WriteLine("Exception: " + e.Message);
    }
  }
}