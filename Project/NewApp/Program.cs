using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Flower fl1 = new Flower();
        fl1.EnterData();
        
        fl1.Display();
    }
}