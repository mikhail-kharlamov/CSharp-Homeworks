namespace ParseTree;

using Node;

public class OperandNode : Node
{
    private int Value { get; set; }

    public void SetValue(int value)
    {
        this.Value = value;
    }

    public override int Evaluate() => this.Value;

    public override string Print() => this.Value.ToString();
}