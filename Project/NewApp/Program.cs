using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Employee epl1 = new Employee();
        epl1.EnterData();
        
        epl1.Display();
    }
}