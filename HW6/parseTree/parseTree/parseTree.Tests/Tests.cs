namespace Tests;

using ParseTree;

public class Tests
{
    [Test]
    public void ParseTreeExtractTreeFromStringAndEvaluateSimpleDataTest()
    {
        var tree = new ParseTree();
        tree.ExtractTreeFromString("(+ 3 (* 2 2))");
        var value = tree.Evaluate();
        Assert.That(value, Is.EqualTo(7));
    }
    
    [Test]
    public void ParseTreeExtractTreeFromStringAndEvaluateWithAllOfTheOperatorsTest()
    {
        var tree = new ParseTree();
        tree.ExtractTreeFromString("(+ 3 (* (/ 10 5) (- 12 10)))");
        var value = tree.Evaluate();
        Assert.That(value, Is.EqualTo(7));
    }
}