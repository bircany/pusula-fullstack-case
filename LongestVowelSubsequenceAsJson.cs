/* Bir kelime listesi veriliyor. Her kelimenin ardışık sesli harflerinden oluşan en uzun alt diziyi bulun ve
    JSON formatında kelime ile birlikte alt diziyi ve uzunluğunu döndürün.
*/

using System.Text;
using System.Text.Json;

public static class LongestVowelSubsequence
{
    private static readonly HashSet<char> Vowels = new() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

    public static string LongestVowelSubsequenceAsJson(List<string> words)
    {
        try
        {
            if (words == null)
                throw new ArgumentNullException(nameof(words), "Liste null olamaz.");

            if (words.Count == 0)
                throw new ArgumentException("Liste boş olamaz.", nameof(words));

            var results = words.Select(GetLongestVowelSequence).ToList();
            return JsonSerializer.Serialize(new ResultObject<VowelResult> { Data = results });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new ResultObject<VowelResult>
            {
                Data = new List<VowelResult>(),
                ErrorMessage = $"Hata: {ex.Message}"
            });
        }
    }

    private static VowelResult GetLongestVowelSequence(string word)
    {
        if (string.IsNullOrEmpty(word))
            return new VowelResult(word ?? "", "", 0);

        var longest = new StringBuilder();
        var current = new StringBuilder();

        foreach (char c in word)
        {
            if (Vowels.Contains(c))
                current.Append(c);
            else
            {
                if (current.Length > longest.Length)
                {
                    longest.Clear();
                    longest.Append(current);
                }
                current.Clear();
            }
        }

        if (current.Length > longest.Length)
        {
            longest.Clear();
            longest.Append(current);
        }

        return new VowelResult(word, longest.ToString(), longest.Length);
    }

    public record VowelResult(string Word, string Sequence, int Length);
    public class ResultObject<T>
    {
        public List<T> Data { get; set; } = new();
        public string? ErrorMessage { get; set; } = null;
    }
}

