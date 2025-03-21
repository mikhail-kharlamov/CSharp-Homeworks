var array = new int[10];

var str = Console.ReadLine();
if (str is null)
{
    Console.WriteLine("ВСЕПЛОХО!!!!!");
    return -1;
}

var массив = str.Split(' ');

var array2 = массив.Select(x => int.Parse(x)).ToArray();

for (var i = 0; i < array2.Length; i++)
{
    if (int.TryParse(массив[i], out int result))
    {
        array2[i] = result;
    }
}

array2.ToList().ForEach(x => Console.Write($"{x} "));
Console.WriteLine();


for (var i = array.Length - 1; i >= 0; --i)
{
    array[i] = i * i;
}

BubbleSort(array);

for (var i = 0; i < array.Length; ++i)
{
    System.Console.Write($"{array[i]} ");
}

System.Console.Write($"\nMean: {Math(array).Mean}\nDispertion: {Math(array).Dispertion}");

(double Mean, double Dispertion) Math(int[] array)
{
    var mean = CalcMean(array);
    double dispertion = 1.0;

    for (var i = 0; i < array.Length; ++i)
    {
        dispertion += System.Math.Pow(array[i] - mean, 2);
    }
    dispertion = dispertion / array.Length;
    return (mean, dispertion);
    
    double CalcMean(int[] array) => array.Sum() / array.Length;
}


void BubbleSort(int[] array)
{
    bool isArraySorted = false;
    while (!isArraySorted)
    {
        
        isArraySorted = true;
        for (var i = 1; i < array.Length; ++i)
        {
            if (array[i - 1] > array[i])
            {
                (array[i - 1], array[i]) = (array[i], array[i - 1]);
                isArraySorted = false;
            }
        }
    }
}

return 0;