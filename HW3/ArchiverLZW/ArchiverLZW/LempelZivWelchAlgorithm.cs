namespace ArchiverLZW;

using TrieDataStructure;
using System.Text;

public class LempelZivWelchAlgorithm
{
    public static byte[] Encode(byte[] text)
    {
        var table = new Trie();
        var currentString = string.Empty; 
        List<int> stream = new();
        for (var i = 0; i < 256; i++)
        {
            table.Add(((char)i).ToString());
        }
        
        foreach (var letter in text.Select(number => (char)number))
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
        foreach (var number in stream)
        {
            var element = table.GetElementByNumber(number);
            if (table.Contains(currentString + element) != 0)
            {
                currentString += element;
                continue;
            }
            table.Add(currentString + element[0]);
            originalFile += currentString;
            currentString = element;
        }

        if (stream.Count != 0)
        {
            originalFile += currentString;
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
}