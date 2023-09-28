using System.Collections.Specialized;

internal class Program
{
    private static void Main (String [] args)
    {
        float a = 5;
        if (a >= 9){
            System.Console.WriteLine("Hoc sinh hoc luc gioi");
        }else if (a >= 7.5){
            System.Console.WriteLine("Hoc sinh hoc luc kha");
        }else if (a >= 6){
            System.Console.WriteLine("Hoc sinh hoc luc trung binh");
        }else if(a >= 4.5) {
            System.Console.WriteLine("Hoc sinh hoc luc yeu");
        }else {
            System.Console.WriteLine("Hoc sinh hoc luc kem");
        }

    }
}

    

