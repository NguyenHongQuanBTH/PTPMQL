namespace NewApp.Models
{
    public class Employee : Person
    {
        public string EmployeeCode { get; set; }
        public void EnterData()
    {
        base.EnterData();
        System.Console.Write("EmployeeCode = ");
        EmployeeCode = Console.ReadLine();
    }
    public void Display()
    {
        base.Display();
        System.Console.Write("Ma nhan vien: {0}", EmployeeCode);
    }
    }
}