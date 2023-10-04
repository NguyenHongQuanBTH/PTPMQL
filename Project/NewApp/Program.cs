using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Employee epl1 = new Employee();
        
        
        string ten = "Nguyen Hong Quan";
        string id = "k64";
        string diachi = "Quang Ninh";
        int tuoi = 22;
        Console.WriteLine("{0} sinh nam {1}", ten, id, diachi, epl1.GetYearOfBirth(tuoi));
        epl1.Display2(ten, id, diachi, tuoi);

        
        
    }
}