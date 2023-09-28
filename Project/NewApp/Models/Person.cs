

namespace NewApp.Models
{
    public class Person
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    
    public void EnterData()
    {
        System.Console.Write("FullName = ");
        FullName = Console.ReadLine();
        System.Console.Write("Address = ");
        Address = Console.ReadLine();
        System.Console.Write("Age = ");
         
        try{
            Age = Convert.ToInt16(Console.ReadLine());
        }catch(Exception e)
        {
            Age = 0;
        }
    }
    public void Display()
        {
            System.Console.WriteLine("{0} - {1} tuoi", FullName, Address, Age);
        }
    }
}
