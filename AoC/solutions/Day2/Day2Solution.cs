namespace Day2;
class Day2Solution 
{

  static void Main(string[] args)
  {
    try
    {
      string[] lines = File.ReadAllLines("/Users/jordanmurray/Workspaces/advent-of-code/AoC/res/day2.txt");
      string[] testData = {"7 6 4 2 1", "1 2 7 8 9", "9 7 6 2 1", "1 3 2 4 5", "8 6 4 4 1", "1 3 6 7 9"};
      // string[] testData = {"1 3 2 4 5"};

      int result = 0;
      const int threshold = 3;

      foreach(string line in lines)
      {
        int[] arr = line.Split(" ").Select(x => int.Parse(x)).ToArray();

        bool isSafe = true;
        bool levelRemoved = false;
        int i = 0;

        while(i < arr.Length - 1) 
        {
          int diff = Math.Abs(arr[i] - arr[i + 1]);

          if((arr[0] > arr[1] && !arr.SequenceEqual(arr.OrderByDescending(x => x))) || (arr[0] < arr[1] && !arr.SequenceEqual(arr.OrderBy(x => x))) || diff > threshold)
          {
            if(levelRemoved)
            {
              isSafe = false;
              break;
            }
            arr = arr.Where((_, index) => index != (1)).ToArray();
            levelRemoved = true;
            // if(i > 0) i--;
            i = 0;
          } 
          else
          {
            i++;
          }
        }

        if(isSafe)
        {
          result++;
          Console.WriteLine("safe");
        } else
        {
          Console.WriteLine("not safe");

        }
      }

      Console.WriteLine("Is safe number: " + result);

    } catch(Exception e)
    { 
      Console.WriteLine(e.Message);
    }
  }
  static void partOne()
  {
    try
    {
      string[] lines = File.ReadAllLines("/Users/jordanmurray/Workspaces/advent-of-code/AoC/res/day2.txt");
      string[] testData = {"7 6 4 2 1", "1 2 7 8 9", "9 7 6 2 1", "1 3 2 4 5", "8 6 4 4 1", "1 3 6 7 9"};

      int result = 0;
      const int threshold = 3;

      foreach(string line in testData)
      {
        int[] arr = line.Split(" ").Select(x => int.Parse(x)).ToArray();

        bool isSafe = true;

        bool isIncreasing = arr[0] < arr[1];
        bool isDecreasing = arr[0] > arr[1];

        for(int i = 0; i < arr.Length - 1; i++) 
        {

          if(isIncreasing && arr[i] > arr[i + 1])
          {
            isSafe = false;
            break;
          }

          if(isDecreasing && arr[i] < arr[i + 1])
          {
            isSafe = false;
            break;
          }

          int check = Math.Abs(arr[i] - arr[i + 1]);

          if(check > threshold || check == 0)
          {
            isSafe = false;
            break;
          }
        }

        if(isSafe)
        {
          result++;
        }
      }

      Console.WriteLine("Is safe number: " + result);

    } catch(Exception e)
    { 
      Console.WriteLine(e.Message);
    }
  }
}