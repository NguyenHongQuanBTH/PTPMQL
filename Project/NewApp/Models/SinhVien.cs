namespace NewApp.Models
{
    public class SinhVien
    {
        
        public string Tensinhvien { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }


    public void EnterData()
    {
        System.Console.Write("FullName = ");
        Tensinhvien = Console.ReadLine();
        System.Console.Write("Address = ");
        Address = Console.ReadLine();
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
            System.Console.WriteLine("{0} - {1} - {2} tuoi", Tensinhvien, Address, Age);
        }
    
    }
}
