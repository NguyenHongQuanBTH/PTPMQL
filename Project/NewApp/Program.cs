using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Person ps1 = new Person();
        ps1.EnterData();
        
        ps1.Display();
    }
}