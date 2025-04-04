using System;

namespace BurrowsWheeler;


public class BurrowsWheelerTransform
{
    public (string, int) StraightTransform(string input)
    {
        if (string.Empty(input))
        {
            return (input, 0);
        }
        
        var transformTable = new char[symbolsArray.Length, symbolsArray.Length];

        transformTable[0] = input.ToCharArray();
        char firstLetter = symbolsArray[0];
        for (var i = 1; i < symbolsArray.Length; i++)
        {
            transformTable[i, ^1] = firstLetter;
            for (var j = 0; j < (symbolsArray.Length - 1); i++)
            {
                transformTable[i, j] = transformTable[i - 1, j + 1]
            }
        }
        
    }

    public InverseTransform(string input, int numberOfString)
    {
        
    }
}