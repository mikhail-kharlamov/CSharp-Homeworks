using BurrowsWheeler;

var (transformed, pos) = BurrowsWheelerTransform.StraightTransform("abacaba");
Console.WriteLine(transformed);
Console.WriteLine(pos);
var text = BurrowsWheelerTransform.InverseTransform(transformed, pos);
Console.WriteLine(text);