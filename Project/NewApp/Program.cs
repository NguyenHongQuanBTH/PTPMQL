using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Student std1 = new Student();
        Student std2 = new Student();
        std1.FullName = "Nguyen Hong Quan";
        std1.StudentID = "1921050489";
        std1.Address = "Quang Ninh";
        std1.Age = 23;
        std1.Display();
        std2.FullName = "Nguyen Duy Anh";
        std2.StudentID = "2021050489";
        std2.Address = "Ha Noi";
        std2.Age = 22;
        std2.Display();
    }
}