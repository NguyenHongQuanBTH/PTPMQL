namespace NewApp.Models
{
    public class SinhVien
    {
        private string fullName;
        private string MaSinhVien;
        private string address;
        private int age;

        public string FullName { get => fullName; set => fullName = value; }

        public string Address { get => address; set => address = value; }

        public string MaSinhVien1 { get => MaSinhVien; set => MaSinhVien = value; }
        public int Age { get => age; set => age = value; }

        public SinhVien()
        {
            FullName = "Nguyen Hong Quan";
            MaSinhVien = "1921050489";
            Address = "Quang Ninh";
            Age = 23;

        }
        public void Display()
        {
            System.Console.WriteLine("{0} - {1} - {2} tuoi", FullName, MaSinhVien, address, age);
        }
    }
}
