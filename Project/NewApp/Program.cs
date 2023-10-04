using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Person ps = new Person();
        string str = "Nguyen Hong Quan";
        int a = 22;
        System.Console.WriteLine("{0} sinh nam {1}", str, ps.GetYearOfBirth(a));
    }
}