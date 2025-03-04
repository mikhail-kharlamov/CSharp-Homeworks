namespace TrieDataStructure.Test;

public class Tests
{
    [Test]
    public void AddAndContainsTest()
    {
        var TestTrie = new Trie();
        TestTrie.Add("he");
        var isElementInTrie = TestTrie.Contains("he");
        Assert.That(isElementInTrie, Is.True);
    }

    [Test]
    public void AddAndContainsTwoElementsTest()
    {
        var TestTrie = new Trie();
        TestTrie.Add("he");
        TestTrie.Add("hers");
        Assert.That(TestTrie.Contains("he"), Is.True);
        Assert.That(TestTrie.Contains("hers"), Is.True);
    }

    [Test]
    public void AddAndRemoveTest()
    {
        var testTrie = new Trie();
        testTrie.Add("he");
        testTrie.Add("hers");
        Assert.That(testTrie.Remove("he"), Is.True);
        Assert.That(testTrie.Contains("he"), Is.False);
        Assert.That(testTrie.Contains("hers"), Is.True);
        Assert.That(testTrie.Remove("hers"), Is.True);
        Assert.That(testTrie.Contains("hers"), Is.False);
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