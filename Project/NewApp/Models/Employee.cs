namespace NewApp.Models
{
    public class Employee
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int Age { get; set; }
        public float HeSoLuong { get; set; }

    
    public void EnterData()
    {
        System.Console.Write("MaNhanVien = ");
        MaNhanVien = Console.ReadLine();
        System.Console.Write("TenNhanVien = ");
        TenNhanVien = Console.ReadLine();
        System.Console.Write("Age = ");
        Age = Convert.ToInt16(Console.ReadLine());
        
    }
    
    public void Display()
        {
            System.Console.WriteLine("{0} - {1} - {2} tuoi", MaNhanVien, TenNhanVien, Age);
        }
    }
}