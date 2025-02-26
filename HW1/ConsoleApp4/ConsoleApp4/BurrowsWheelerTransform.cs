namespace BurrowsWheeler;

public class BurrowsWheelerTransform
{
    public static (string, int) StraightTransform(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return (string.Empty, -1);
        }

        var indices = Enumerable.Range(0, input.Length).ToArray();

        Array.Sort(indices, (a, b) =>
        {
            for (var i = 0; i < indices.Length; i++)
            {
                var indexA = (a + i) % input.Length;
                var indexB = (b + i) % input.Length;
                if (input[indexA] != input[indexB])
                {
                    return input[indexA].CompareTo(input[indexB]);
                }
            }
            return 0;
        });
        
        var output = string.Concat(indices.Select(i => input[(i + input.Length - 1) % input.Length]));
        var indexOfOriginalString = Array.IndexOf(indices, 0);
        
        return (output, indexOfOriginalString);
    }

    public static string InverseTransform(string transformedText, int indexOfOriginalString)
    {
        if (string.IsNullOrEmpty(transformedText) || transformedText.Length <= indexOfOriginalString ||
            indexOfOriginalString < 0)
        {
            return string.Empty;
        }

        var charArray = transformedText.ToCharArray();
        var sortedArray = transformedText.ToCharArray();
        Array.Sort(sortedArray);

        List<int> mapping = new(transformedText.Length);
        var isUsed = new bool[transformedText.Length];

        for (var i = 0; i < transformedText.Length; i++)
        {
            for (var j = 0; j < sortedArray.Length; j++)
            {
                if ((sortedArray[j] == charArray[i]) && !isUsed[j])
                {
                    isUsed[j] = true;
                    mapping.Add(j);
                    break;
                }
            }
        }
        
        var originalString = new char[transformedText.Length]; 
        var currentIndex = indexOfOriginalString;

        for (var i = transformedText.Length - 1; i >= 0; i--)
        {
            originalString[i] = charArray[currentIndex];
            currentIndex = mapping[currentIndex];
        }
        
        return new string(originalString);
    }
}