using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        SinhVien sv1 = new SinhVien();
        SinhVien sv2 = new SinhVien();
        sv1.FullName = "Nguyen Hong Quan";
        sv1.Address = "Quang Ninh";
        sv1.Age = 23;
        sv1.Display();
        sv2.FullName = "Tran Hong Hanh";
        sv2.Address = "Thai Binh";
        sv2.Age = 22;
        sv2.Display();
    }
}