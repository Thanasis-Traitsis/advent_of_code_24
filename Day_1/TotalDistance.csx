List<int> numbers1 = new List<int>();
List<int> numbers2 = new List<int>();

// ✨🎄 This is how I read my data from the txt file ✨🎄
string filePath = "day1.txt";
string[] lines = File.ReadAllLines(filePath);

foreach (string line in lines)
{
    string[] numbers = line
        .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    numbers1.Add(int.Parse(numbers[0]));
    numbers2.Add(int.Parse(numbers[1]));
}

// ✨🎄 This is my approach to the solution ✨🎄
int totalDistance = findTotalDistance(numbers1, numbers2);

Console.WriteLine("The total distance is: " + totalDistance);

int findTotalDistance(List<int> nums1, List<int> nums2)
{
    int sum = 0;
    nums1.Sort();
    nums2.Sort();

    for (int i = 0; i < nums1.Count; i++)
    {
        sum += Math.Abs(nums1[i] - nums2[i]);
    }

    return sum;
}