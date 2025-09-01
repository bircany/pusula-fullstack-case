using System;
using System.Text.Json;


public static class MaxIncreasingSubArrayAsJson
{
    public static string MaxIncreasingSubarrayAsJson(List<int> numbers)
    {
        try
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers), "Liste null olamaz.");

            if (numbers.Count == 0)
                throw new ArgumentException("Liste boş olamaz.", nameof(numbers));

            var maxSubarray = FindMaxSumIncreasingSubarray(numbers);
            return JsonSerializer.Serialize(new ResultObject<int> { Data = maxSubarray });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new ResultObject<int>
            {
                ErrorMessage = $"Hata: {ex.Message}"
            });
        }
    }

    private static List<int> FindMaxSumIncreasingSubarray(List<int> numbers)
    {
        var maxSubarray = new List<int>();
        long maxSum = numbers[0];
        var currentArr = new List<int> { numbers[0] };
        long currentSum = numbers[0];

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                currentArr.Add(numbers[i]);
                currentSum += numbers[i];
            }
            else
            {
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSubarray = new List<int>(currentArr);
                }
                currentArr = new List<int> { numbers[i] };
                currentSum = numbers[i];
            }
        }

        if (currentSum > maxSum)
            maxSubarray = currentArr;

        return maxSubarray;
    }

    public class ResultObject<T>
    {
        public List<T> Data { get; set; } = new();
        public string? ErrorMessage { get; set; } = null;
    }
}

