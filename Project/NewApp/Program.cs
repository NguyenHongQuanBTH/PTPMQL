using System.Collections.Specialized;

internal class Program
{
    private static void Main (String [] args)
    {
        int day = 5;
        switch(day)
        {
            case 1 : System.Console.WriteLine("Chu Nhat"); break;
            case 2 : System.Console.WriteLine("Thu Hai"); break;
            case 3 : System.Console.WriteLine("Thu Ba"); break;
            case 4 : System.Console.WriteLine("Thu Tu"); break;
            case 5 : System.Console.WriteLine("Thu Nam"); break;
            case 6 : System.Console.WriteLine("Thu Sau"); break;
            case 7 : System.Console.WriteLine("Thu Bay"); break;
            default : 
            System.Console.WriteLine("Khong phai ngay trong tuan");
            break;
        }
    }
}

    

