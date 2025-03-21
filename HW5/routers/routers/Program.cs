namespace Routers;

public class Routers
{
    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: routers <file_to_read> <file_to_write>");
            return;
        }
        
        var fileToRead = args[0];
        var fileToWrite = args[1];

        try
        {
            using (var reader = new StreamReader(fileToRead))
            {
                var line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}