// Create class IntegerRatioPosNeg
public class IntegerRatioPosNeg
{
    //create function that calls CalculateRatios
    public IntegerRatioPosNeg()
    {
        
    }

    //Create a public method that runs and times the CalculateRatios method
    public void Run()
    {
        Console.WriteLine("Running IntegerRatioPosNeg...");
        // Start the timer
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        // Call the CalculateRatios method
        CalculateRatios();
        // Stop the timer
        stopwatch.Stop();
        Console.WriteLine("Elapsed time: " + stopwatch.ElapsedMilliseconds + " ms");
    }

    public void CalculateRatios()
    {
        // Initialize the numbers database
        int[] numbersDatabase = new int[12000];
        Random random = new Random();

        // Populate the numbers database with random integers
        for (int i = 0; i < 12000; i++)
        {
            numbersDatabase[i] = random.Next(-500, 599);
        }

        // Create a float[3] array with structure [positive, negative, zero]
        float[] ratioCollection = new float[3];

        // Loop through numbersDatabase
        for (int i = 0; i < numbersDatabase.Length; i++)
        {
            // Sleep for 0.01 seconds
            System.Threading.Thread.Sleep(1);

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

        // Convert counts to ratios
        int totalNumbers = numbersDatabase.Length;
        ratioCollection[0] /= totalNumbers;
        ratioCollection[1] /= totalNumbers;
        ratioCollection[2] /= totalNumbers;

        // Output the results with rounding to 6 decimal places
        Console.WriteLine("Positive ratio: " + Math.Round(ratioCollection[0], 6));
        Console.WriteLine("Negative ratio: " + Math.Round(ratioCollection[1], 6));
        Console.WriteLine("Zero ratio: " + Math.Round(ratioCollection[2], 6));

        // Print total numbers
        Console.WriteLine("Total numbers: " + totalNumbers);
    }
}
