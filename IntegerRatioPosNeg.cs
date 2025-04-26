// Create class IntegerRatioPosNeg
using System.Numerics;

public class IntegerRatioPosNeg
{
    //create function that calls CalculateRatios
    public IntegerRatioPosNeg()
    {
        
    }

    public void Run()
    {
        // Initialize the numbers database
        int[] numbersDatabase = new int[1200000];
        Random random = new Random();

        // Populate the numbers database with random integers
        for (int i = 0; i < 12000; i++)
        {
            numbersDatabase[i] = random.Next(-500, 599);
        }
        RunSlow(numbersDatabase);

        RunStandard(numbersDatabase);
    }

    //Create a public method that runs and times the CalculateRatios method
    public void RunStandard(int[] numbersDatabase)
    {
        Console.WriteLine("Running IntegerRatioPosNeg...");

        //get GetTotalMemory() before running the method
        long memoryBefore = GC.GetTotalMemory(true);
        // Start the timer
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        // Call the CalculateRatios method
        CalculateRatiosStandard(numbersDatabase);
        // Stop the timer
        stopwatch.Stop();
        //get GetTotalMemory() after running the method
        long memoryAfter = GC.GetTotalMemory(true);

        Console.WriteLine("Elapsed time: " + stopwatch.ElapsedMilliseconds + " ms");
        Console.WriteLine("Memory used: " + (memoryAfter - memoryBefore) + " bytes");
    }

    public void RunSlow(int[] numbersDatabase)
    {
        Console.WriteLine("Running slow calculations...");

        //get GetTotalMemory() before running the method
        long memoryBefore = GC.GetTotalMemory(true);
        // Start the timer
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        // Call the CalculateRatios method
        CalculateRatiosStandard(numbersDatabase);
        // Stop the timer
        stopwatch.Stop();
        //get GetTotalMemory() after running the method
        long memoryAfter = GC.GetTotalMemory(true);

        Console.WriteLine("Slowly Elapsed time: " + stopwatch.ElapsedMilliseconds + " ms");
        Console.WriteLine("Slowly Memory used: " + (memoryAfter - memoryBefore) + " bytes");
    }


    public void CalculateRatiosStandard(int[] numbersDatabase)
    {
        int totalNumbers = numbersDatabase.Length;

        // Create a float[3] array with structure [positive, negative, zero]
        float[] ratioCollection = new float[3];

        // Loop through numbersDatabase
        for (int i = 0; i < totalNumbers; i++)
        {
            // Check if number is greater than 0
            if (numbersDatabase[i] > 0)
            {
                ratioCollection[0]++;
            }
            // Check if number is less than 0
            else if (numbersDatabase[i] < 0)
            {
                ratioCollection[1]++;
            }
            // Check if number is equal to 0
            else
            {
                ratioCollection[2]++;
            }
        }

        foreach (int i in ratioCollection)
        {
            float ratio = i / (float)(totalNumbers);
            Console.WriteLine(Math.Round(ratio, 6));
        }
    }

    public void CalculateRatiosSlowly(int[] numbersDatabase)
    {
        // Create a float[3] array with structure [positive, negative, zero]
        float[] ratioCollection = new float[3];

        // Loop through numbersDatabase
        for (int i = 0; i < numbersDatabase.Count(); i++)
        {
            // Check if number is greater than 0
            if (numbersDatabase.Where(x => x == numbersDatabase[i]).Any(x => x > 0))
            {
                ratioCollection[0]++;
            }
            // Check if number is less than 0
            else if (numbersDatabase.Where(x => x == numbersDatabase[i]).Any(x => x < 0))
            {
                ratioCollection[1]++;
            }
            // Check if number is equal to 0
            else
            {
                ratioCollection[2]++;
            }
        }

        foreach (int i in ratioCollection)
        {
            //Changed so that .Length is ran on every iteration
            float ratio = i / (float)(numbersDatabase.Count());
            Console.WriteLine(Math.Round(ratio, 6));
        }
    }
}
