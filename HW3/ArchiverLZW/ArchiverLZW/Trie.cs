namespace TrieDataStructure;

/// <summary>
/// Class of data structure Trie.
/// </summary>>
public class Trie
{
    private Node _root = new Node();
    
    private int size { get; set; }
    
    /// <summary>
    /// Adds element to the trie.
    /// </summary>>
    /// <param name="element">Element to add.</param>
    /// <returns>True if element hasn't been in trie before.</returns>
    public bool Add(string element)
    {
        var node = this._root;
        foreach (var letter in element)
        {
            if (!node.Children.ContainsKey(letter))
            {
                node.Children[letter] = new Node();
            }
            node = node.Children[letter];
        }

        if (node.ElementNumber != 0)
        {
            return false;
        }
        this.size++;
        node.ElementNumber = this.size;
        return true;
    }

    /// <summary>
    /// Checks is the element in trie.
    /// </summary>>
    /// <param name="element">Element to check.</param>
    /// <returns>Number in the last node of element. Zero if trie doesn't contain it.</returns>
    public int Contains(string element)
    {
        var node = this._root;
        foreach (var letter in element)
        {
            if (!node.Children.ContainsKey(letter))
            {
                return 0;
            }
            node = node.Children[letter];
        }
        return node.ElementNumber;
    }

    /// <summary>
    /// Removes element from the trie.
    /// </summary>>
    /// <param name="element">Element to remove.</param>
    /// <returns>True if element really has been in trie.</returns>
    public bool Remove(string element)
    {
        var (isElementInTree, isChildHasChildren) = DeleteRecursively(this._root, element, 0);
        if (isElementInTree)
        {
            this.size--;
        }
        return isElementInTree;
    }

    private (bool, bool) DeleteRecursively(Node node, string element, int numberOfLetter)
    {
        if (node.ElementNumber != 0 && node.Children.Count == 0 && element.Length == numberOfLetter)
        {
            return (true, false);
        }
        if (node.ElementNumber != 0 && element.Length == numberOfLetter)
        {
            node.ElementNumber = 0;
            return (true, true);
        } 
        if (node.Children.Count == 0 && element.Length == numberOfLetter)
        {
            return (false, false);
        }
        var letter = element[numberOfLetter];
        var children = node.Children[letter];
        var (isElementInTree, isChildHasChildren) = DeleteRecursively(children, element, numberOfLetter + 1);
        if (!isElementInTree)
        {
            return (false, false);
        }

        if (!isChildHasChildren)
        {
            node.Children.Remove(element[numberOfLetter]);
        }
        return (isElementInTree, node.Children.Count != 0);
    }
    
    /// <summary>
    /// Counts how many elements starts with prefix.
    /// </summary>>
    /// <param name="prefix">Prefix for counting words.</param>
    /// <returns>Count of elements that starts with this prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        var node = this._root;
        foreach (var letter in prefix)
        {
            if (!node.Children.ContainsKey(letter))
            {
                return 0;
            }
            node = node.Children[letter];
        }

        var count =  PrefixCounterRecursively(node);
        if (node.ElementNumber != 0)
        {
            count++;
        }
        return count;
    }

    private int PrefixCounterRecursively(Node node)
    {
        if (node.Children.Count == 0)
        {
            return node.ElementNumber != 0? 1 : 0;
        }

        var counter = 0;
        foreach (var childNode in node.Children.Values)
        {
            counter += PrefixCounterRecursively(childNode);
        }
        return counter;
    }

    /// <summary>
    /// Method for getting element by number in the last node of this element.
    /// </summary>>
    /// <param name="number">Number in the last node of this element.</param>
    /// <returns>Element in trie.</returns>
    public string GetElementByNumber(int number)
    {
        var element = GetElementByNumberRecursive(number, this._root);
        return element.Item1;
    }

    private (string, bool) GetElementByNumberRecursive(int number, Node node)
    {
        if (node.ElementNumber == number)
        {
            return ("", true);
        }

        foreach (var edge in node.Children)
        {
            var (element, isNumberIsNext) = GetElementByNumberRecursive(number, edge.Value);
            if (isNumberIsNext)
            {
                return (edge.Key + element, true);
            }
        }
        
        return ("", false);
    }
    
    /// <summary>
    /// Checks the size of the trie.
    /// </summary>>
    /// <returns>How many elements in trie.</returns>
    public int Size()
    {
        return this.size;
    }

    private class Node
    {
        public int ElementNumber { set; get; }
        public Dictionary<char, Node> Children { get; } = new();
    }
}