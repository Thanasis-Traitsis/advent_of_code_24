int totalSafeReports = 0;

// ✨🎄 This is how I read my data from the txt file ✨🎄
string filePath = "day2.txt";
string[] lines = File.ReadAllLines(filePath);

foreach (string line in lines)
{
    string[] numbers = line
        .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    // ✨🎄 Convert the string array that I got from the Split to a List<int> ✨🎄
    List<int> list = numbers.Select(int.Parse).ToList();

    totalSafeReports += AddSafeReport(list);
}

Console.WriteLine("The total safe reports are: " + totalSafeReports);

// ✨🎄 This is my approach to the solution ✨🎄
int AddSafeReport(List<int> nums)
{
    if (isSafe(nums))
    {
        return 1;
    }

    for (int i = 0; i < nums.Count; i++)
    {
        List<int> newList = new List<int>(nums);
        newList.RemoveAt(i);

        if (isSafe(newList))
        {
            return 1;
        }
    }

    return 0;
}

bool isSafe(List<int> nums)
{
    bool isIncreasing = nums[1] > nums[0];

    for (int i = 1; i < nums.Count; i++)
    {
        int diff = nums[i] - nums[i - 1];

        if ((isIncreasing && (diff <= 0 || diff > 3)) ||
            (!isIncreasing && (diff >= 0 || -diff > 3)))
        {
            return false;
        }
    }

    return true;
}
