namespace NewApp.Models
{
    public class Employee 
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int Age { get; set; }
        


    public void EnterData()
    {
        System.Console.Write("MaNhanVien = ");
        MaNhanVien = Console.ReadLine();
        System.Console.Write("TenNhanVien = ");
        TenNhanVien = Console.ReadLine();
        System.Console.Write("Age = ");
        try{
            Age = Convert.ToInt16(Console.ReadLine());
        }catch (Exception e)  
        {
            Age = 25;
        }
    }
    public void Display()
        {
            System.Console.WriteLine("{0} - {1} - {2} tuoi", MaNhanVien, TenNhanVien, Age);
        }
    }
}