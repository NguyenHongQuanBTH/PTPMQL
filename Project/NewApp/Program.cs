using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Student std1 = new Student();
        std1.EnterData();
        std1.StudentCode = "1921050489";
        std1.Display();
    }
}