using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Person ps1 = new Person();
        Person ps2 = new Person();
        ps1.FullName = "Nguyen Hong Quan";
        ps1.Address = "Quang Ninh";
        ps1.Age = 23;
        ps1.Display();
    }
}