using System.Collections.Specialized;

internal class Program
{
    private static void Main (String [] args)
    {
        int a = 12;
        if (a < 0)
        {
            System.Console.WriteLine("{0} la so nguyen am", a);
        }else{
            if (a % 2 == 0){
                System.Console.WriteLine("{0} la so nguyen duong chan", a);
            }else{
                System.Console.WriteLine("(0) la so nguyen duong le", a);
            }
        }

    }
}

    

