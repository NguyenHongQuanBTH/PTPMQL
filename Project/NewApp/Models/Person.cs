

namespace NewApp.Models
{
    public class Person
    {
        public string FullName { get; set; }
        public int PersonID { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    
    public Person()
    {
        FullName = "Nguyen Hong Quan";
        PersonID = 1921050489;
        Address = "Quang Ninh";
        Age = 23;

        
    }
    public void Display2(string ten, string id, string diachi, int tuoi)
        {
            System.Console.WriteLine("Sinh Vien {0} - {1} - {2} - {3} tuoi", FullName, PersonID, Address, Age);
        }
    
    public int GetYearOfBirth (int Age)
        {
            int YearOfBirth = 2023 - Age;
            return YearOfBirth;
        }
    }
}
