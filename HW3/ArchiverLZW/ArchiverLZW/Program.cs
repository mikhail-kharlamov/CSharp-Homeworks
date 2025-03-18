namespace Archiver;

using AlgorithmLZW;

/// <summary>
/// The main class for connection with user in console.
/// </summary>>
public class Archiver
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Usage();
            return;
        }
        
        var mode = args[0];
        if ((mode != "-u") && (mode != "-c"))
        {
            Usage();
            return;
        }
        
        var filename = args[1];
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} does not exist");
        }
        
        byte[] bytesStream;
        try
        {
            bytesStream = File.ReadAllBytes(filename);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading file: {e.Message}");
            return;
        }
        
        var outputFilePath = Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename));
        
        if (mode == "-c")
        {
            var encodedBytes = LempelZivWelchAlgorithm.Encode(bytesStream);
            var compressionCoefficient = (float)bytesStream.Length / encodedBytes.Length;
            try
            {
                File.WriteAllBytes(outputFilePath += ".zipped", encodedBytes);
                Console.WriteLine($"Successfully encoded and saved to {outputFilePath}");
                Console.WriteLine($"Compression Coefficient: {compressionCoefficient}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error writing file: {e.Message}");
            }
        }
        else
        {
            var decodedBytes = LempelZivWelchAlgorithm.Decode(bytesStream);
            try
            { 
                File.WriteAllBytes(outputFilePath, decodedBytes);
                Console.WriteLine($"Successfully decoded and saved to {outputFilePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error with file writing: {e.Message}");
            }
        }
    }
    
    private static void Usage()
    {
        Console.WriteLine("Usage: Archiver -c <input-file> (to encode)");
        Console.WriteLine("       Archiver -u <input-file> (to decode)");
    }

    private static LempelZivWelchAlgorithm _archiveAlgorithm = new LempelZivWelchAlgorithm();
}