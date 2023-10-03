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
        ps2.FullName = "Tran Hong Hanh";
        ps2.Address = "Thai Binh";
        ps2.Age = 22;
        ps2.Display();
    }
}