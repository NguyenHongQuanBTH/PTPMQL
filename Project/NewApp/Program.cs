using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Person std1 = new Person();
        
        
        string ten = "Nguyen Hong Quan";
        string id = "1921050489";
        string diachi = "Quang Ninh";
        int tuoi = 22;
        Console.WriteLine("{0} sinh nam {1}", ten, id, diachi, std1.GetYearOfBirth(tuoi));
        std1.Display2(ten, id, diachi, tuoi);

        
        
    }
}