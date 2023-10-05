using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        SinhVien sv1 = new SinhVien();
        sv1.EnterData();
        
        sv1.Display();
    }
}