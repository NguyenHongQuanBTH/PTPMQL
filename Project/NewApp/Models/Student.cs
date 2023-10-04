namespace NewApp.Models
{
    public class Student
    {
        public string FullName { get; set; }
        public string StudentID { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    
    public Student()
    {
        FullName = "Nguyen Hong Quan";
        StudentID = "1921050489";
        Address = "Quang Ninh";
        Age = 23;

        
    }
     public int GetYearOfBirth (int Age)
        {
            int YearOfBirth = 2023 - Age;
            return YearOfBirth;
        }
    public void Display2(string ten, string id, string diachi, int tuoi)
        {
            System.Console.WriteLine("Sinh Vien {0} - {1} - {2} - {3} tuoi", FullName, StudentID, Address, Age);
        }

   
    }
}
