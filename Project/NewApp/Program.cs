using System.Collections.Specialized;

public class Program
{
    private static void Main (String [] args)
    {
        for (int i = 0; i < 12; i ++)
        {
            if(i == 8) continue;
            System.Console.WriteLine("Vong lap thu {0}", i);
        }
    }
}

    

