using System.Diagnostics;

namespace AlgorithmLZW;

using TrieDataStructure;
using BurrowsWheeler;
using System.Text;

public class LempelZivWelchAlgorithm
{
    public static byte[] Encode(byte[] text, bool transformation = true)
    {
        var table = new Trie();
        var currentString = string.Empty; 
        List<int> stream = new();
        for (var i = 0; i < 256; i++)
        {
            table.Add(((char)i).ToString());
        }

    
        var stringText = string.Join("", text.Select(number => (char)number));
        var isTransformed = Convert.ToInt32(transformation);
        var originalIndex = 0;
        if (transformation)
        {
            (stringText, originalIndex) = BurrowsWheelerTransform.StraightTransform(stringText);
        }
        
        stream.Add(isTransformed);
        stream.Add(originalIndex);
        
        foreach (var letter in stringText)
        {
            if (table.Contains(currentString + letter) != 0)
            {
                currentString += letter;
                continue;
            }
            table.Add(currentString + letter);
            stream.Add(table.Contains(currentString));
            currentString = letter.ToString();
        }

        if (!string.IsNullOrEmpty(currentString))
        {
            stream.Add(table.Contains(currentString));
        }
        
        return ToBytes(stream);
    }

    public static byte[] Decode(byte[] bytes)
    {
        var table = new Trie();
        var originalFile = string.Empty;
        var currentString = string.Empty;
        for (var i = 0; i < 256; i++)
        {
            table.Add(((char)i).ToString());
        }
        
        var stream = FromBytes(bytes);
        var isTransformed = stream[0];
        var originalIndex = stream[1];
        stream.RemoveAt(0);
        stream.RemoveAt(0);
        
        foreach (var number in stream)
        {
            if (number == 261)
            {
                var sosal = "sosal?";
            }
            var element = table.GetElementByNumber(number);
            if (string.IsNullOrEmpty(element))
            {
                element = currentString[0].ToString();
                originalFile += currentString;
                currentString += element;
                table.Add(currentString);
                continue;
            }
            if (table.Contains(currentString + element) != 0)
            {
                currentString += element;
                continue;
            }
            originalFile += currentString;
            table.Add(currentString + element[0]);
            currentString = element;
        }

        if (stream.Count != 0)
        {
            originalFile += currentString;
        }


        if (isTransformed == 1)
        {
            originalFile = BurrowsWheelerTransform.InverseTransform(originalFile, originalIndex);
        }
        
        return Encoding.ASCII.GetBytes(originalFile);
    }

    private static byte[] ToBytes(List<int> stream)
    {
        List<byte> bytes = new();
        
        foreach (var code in stream)
        {
            var byte1 = (byte)((code >> 8) & 0xFF); // AAAA AAAA BBBB BBBB
            var byte2 = (byte)(code & 0xFF);
            bytes.Add(byte1);
            bytes.Add(byte2);
        }
        
        return bytes.ToArray();
    }

    private static List<int> FromBytes(byte[] bytes)
    {
        List<int> stream = new();
        
        for (var i = 0; i < bytes.Length; i += 2)
        {
            var byte1 = bytes[i];
            var byte2 = (i + 1 < bytes.Length) ? bytes[i + 1] : (byte)0;
            
            var code = (byte1 & 0xFF) << 8 | (byte2 & 0xFF);
            
            stream.Add(code);
        }
        
        return stream;
    }
    
    private static BurrowsWheelerTransform _transform = new();
}