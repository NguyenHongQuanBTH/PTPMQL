namespace NewApp.Models
{
    public class Employee
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        

    
    public Employee()
    {
        MaNhanVien = "k64";
        TenNhanVien = "Nguyen Hong Quan";
        Address = "Quang Ninh";
        Age = 23;
        
    }
    
    public void Display2(string ten, string id, string diachi, int tuoi)
        {
            System.Console.WriteLine("Nhan Vien {0} - {1} - {2} - {3} tuoi", MaNhanVien, TenNhanVien, Address, Age);
        }

    public int GetYearOfBirth (int Age)
        {
            int YearOfBirth = 2023 - Age;
            return YearOfBirth;
        }
    }
}