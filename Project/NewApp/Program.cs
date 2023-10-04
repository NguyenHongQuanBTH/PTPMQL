using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Employee epl1 = new Employee();
        Employee epl2 = new Employee();
        epl1.MaNhanVien = "MDCK64";
        epl1.TenNhanVien = "Nguyen Hong Quan";
        epl1.Age = 23;
        epl1.Display();
        epl2.MaNhanVien = "MDCK65";
        epl2.TenNhanVien = "Nguyen Duy Anh";
        epl2.Age = 22;
        epl2.Display();
    }
}