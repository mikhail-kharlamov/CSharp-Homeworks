namespace parseTree;

using Node;

public class OperatorNode : Node
{
    private char Operator { get; set; }
    
    private Node? LeftChild { get; set; } = null;
    private Node? RightChild { get; set; } = null;

    public void SetOperation(char operation, Node operand1, Node operand2)
    {
        this.Operator = operation;
        this.LeftChild = operand1;
        this.RightChild = operand2;
    }

    public override int Evaluate()
    {
        var leftValue = this.LeftChild is null ? throw new Exception(), this.LeftChild.Evaluate();
        var rightValue = this.RightChild is null ? throw new Exception(), this.RightChild.Evaluate();
        return Operator switch
        {
            '+' => leftValue + rightValue,
            '-' => leftValue - rightValue,
            '*' => leftValue * rightValue,
            '/' => leftValue / rightValue,
            _ => throw new InvalidOperatorException()
        };
    }

    public override string Print() => $"( {Operator} {this.LeftChild.Print()} {this.RightChild.Print()} )";
}