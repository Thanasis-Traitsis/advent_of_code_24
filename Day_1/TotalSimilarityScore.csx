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
int totalSimilarity = findTotalSimilarity(numbers1, numbers2);

Console.WriteLine("The total similarity is: " + totalSimilarity);

int findTotalSimilarity(List<int> nums1, List<int> nums2)
{
    int total = 0;
    Dictionary<int, int> map = new Dictionary<int, int>();

    foreach (int num in nums2)
    {
        if (map.ContainsKey(num))
        {
            map[num] += 1;
        }
        else
        {
            map[num] = 1;
        }
    }

    foreach (int num in nums1)
    {
        total += map.ContainsKey(num) ? num * map[num] : 0;
    }

    return total;
}