namespace ParseTree;

using Node;

public class ParseTree
{
    private Node? Root { get; set; }

    private (Node, int) BuildTree(string input, int index)
    {
        if (index >= input.Length)
        {
            throw new IndexOutOfRangeException();
        }
        
        if (input[index] == ' ')
        {
            index++;
            var node = BuildTree(input, index);
            return node;
        }

        if (input[index] == '(')
        {
            index++;
            var operation = input[index];
            if (!"+-*/".Contains(operation))
            {
                throw new InvalidOperatorException();
            }

            var node = new OperatorNode();
            index++;
            var (leftChild, leftChildIndex) = BuildTree(input, index);
            var (rightChild, rightChildIndex) = BuildTree(input, leftChildIndex);
            node.SetOperation(operation, leftChild, rightChild);
            return (node, rightChildIndex);
        }

        if ("0123456789".Contains(input[index]))
        {
            var number = input[index].ToString();
            index++;
            while (input[index] != ' ' && input[index] != ')')
            {
                number += input[index];
                index++;
            }

            var node = new OperandNode();
            node.SetValue(int.Parse(number));
            return (node, index);
        }
        
        throw new InvalidLiteralException();
    }

    public void ExtractTreeFromString(string input)
    {
        var (node, index) = BuildTree(input, 0);
        Root = node;
    }

    public void ExtractTreeFromFile()
    {
        
    }

    public void PrintTree()
    {
        Root?.Print();
    }

    public int Evaluate()
    {
        return Root?.Evaluate() ?? 0;
    }
}