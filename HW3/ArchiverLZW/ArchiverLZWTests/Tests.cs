namespace AlgorithmLZW.Tests;

using AlgorithmLZW;
using TrieDataStructure;
using System.Text;


public class Tests
{
    [Test]
    public void AlgorithmTest()
    {
        var text = "abacabadabacabae";
        var encodedBytes = LempelZivWelchAlgorithm.Encode(Encoding.ASCII.GetBytes(text));
        var decodedBytes = LempelZivWelchAlgorithm.Decode(encodedBytes);
        
        Assert.That(Encoding.ASCII.GetBytes(text), Is.EqualTo(decodedBytes));
    }

    [Test]
    public void EmptyStringTest()
    {
        var text = string.Empty;
        var encodedBytes = LempelZivWelchAlgorithm.Encode(Encoding.ASCII.GetBytes(text));
        var decodedBytes = LempelZivWelchAlgorithm.Decode(encodedBytes);
        
        Assert.That(Encoding.ASCII.GetBytes(text), Is.EqualTo(decodedBytes));
    }
    
    [Test]
    public void AddAndContainsTest()
    {
        var testTrie = new Trie();
        testTrie.Add("he");
        var isElementInTrie = testTrie.Contains("he")  != 0;
        Assert.That(isElementInTrie, Is.True);
    }

    [Test]
    public void AddAndContainsTwoElementsTest()
    {
        var testTrie = new Trie();
        testTrie.Add("he");
        testTrie.Add("hers");
        Assert.That(testTrie.Contains("he")  != 0, Is.True);
        Assert.That(testTrie.Contains("hers") != 0, Is.True);
    }

    [Test]
    public void AddAndRemoveTest()
    {
        var testTrie = new Trie();
        testTrie.Add("he");
        testTrie.Add("hers");
        Assert.That(testTrie.Remove("he"), Is.True);
        Assert.That(testTrie.Contains("he") != 0, Is.False);
        Assert.That(testTrie.Contains("hers")  != 0, Is.True);
        Assert.That(testTrie.Remove("hers"), Is.True);
        Assert.That(testTrie.Contains("hers") != 0, Is.False);
    }

    [Test]
    public void HowManyStartsWithPrefixTest()
    {
        var testTrie = new Trie();
        testTrie.Add("he");
        testTrie.Add("hers");
        testTrie.Add("hell");
        testTrie.Add("help");
        testTrie.Add("she");
        Assert.That(testTrie.HowManyStartsWithPrefix("he"), Is.EqualTo(4));
    }

    [Test]
    public void SizeTest()
    {
        var testTrie = new Trie();
        testTrie.Add("he");
        testTrie.Add("hers");
        testTrie.Add("hell");
        testTrie.Add("help");
        testTrie.Add("she");
        Assert.That(testTrie.Size, Is.EqualTo(5));
        testTrie.Remove("help");
        testTrie.Remove("he");
        Assert.That(testTrie.Size, Is.EqualTo(3));
    }
}