using System.Runtime.Intrinsics.Arm;
using System;
namespace NewApp.Models
{
    public class Student : Person
    {
        public string StudentCode { get; set; }
    public void EnterData()
    {
        base.EnterData();
        System.Console.Write("StudentCode = ");
        StudentCode = Console.ReadLine();
    }
    public void Display()
    {
        base.Display();
        System.Console.Write("Ma sinh vien: {0}", StudentCode);
    }
    }

    
}
