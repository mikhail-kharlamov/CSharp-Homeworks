using Microsoft.ML;
using Microsoft.ML.Data;

var context = new MLContext();

var data = context.Data.LoadFromTextFile<BostonHousing>("HousingData.csv", hasHeader: true,                                                                 
    separatorChar: ',');

var view = context.Data.FilterRowsByMissingValues(data, "CRIM", "ZN", "INDUS", "CHAS", "NOX", "RM", "AGE", 
    "DIS", "RAD", "TAX", "PTRATIO", "B", "LSTAT", "MEDV");

var trainTestData = context.Data.TrainTestSplit(data, testFraction: 0.2, seed: 0);
var trainData = trainTestData.TrainSet;
var testData = trainTestData.TestSet;

var pipeline = context.Transforms.Concatenate("Features", 
        "CRIM", "ZN", "INDUS", "CHAS", "NOX", "RM", "AGE", 
        "DIS", "RAD", "TAX", "PTRATIO", "B", "LSTAT")
    .Append(context.Transforms.NormalizeMinMax("Features"))  // Helps convergence
    .Append(context.Regression.Trainers.LbfgsPoissonRegression(
        labelColumnName: "MEDV",
        featureColumnName: "Features",
        l1Regularization: 0f,
        l2Regularization: 0f
    ));

var model = pipeline.Fit(trainData);

var predictions = model.Transform(testData);
var metrics = context.Regression.Evaluate(predictions, labelColumnName: "MEDV");

Console.WriteLine($"R-Squared: {metrics.RSquared}");
Console.WriteLine($"Mean Absolute Error: {metrics.MeanAbsoluteError}");
Console.WriteLine($"Mean Squared Error: {metrics.MeanSquaredError}");



public class BostonHousing
{
    [LoadColumn(0)]
    public float CRIM { get; set; }

    [LoadColumn(1)]
    public float ZN { get; set; }

    [LoadColumn(2)]
    public float INDUS { get; set; }
    
    [LoadColumn(3)]
    public float CHAS { get; set; }

    [LoadColumn(4)]
    public float NOX { get; set; }
    
    [LoadColumn(5)]
    public float RM { get; set; }

    [LoadColumn(6)]
    public float AGE { get; set; }
    
    [LoadColumn(7)]
    public float DIS { get; set; }

    [LoadColumn(8)]
    public float RAD { get; set; }

    [LoadColumn(9)]
    public float TAX { get; set; }
    
    [LoadColumn(10)]
    public float PTRATIO { get; set; }

    [LoadColumn(11)]
    public float B { get; set; }

    [LoadColumn(12)]
    public float LSTAT { get; set; }

    [LoadColumn(13)]
    public float MEDV { get; set; }
}