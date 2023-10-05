namespace NewApp.Models
{
    public class Flower : Fruit
    {
        public string FlowerCode { get; set; }
        public void EnterData()
    {
        base.EnterData();
        System.Console.Write("FlowerCode = ");
        FlowerCode = Console.ReadLine();
    }
    public void Display()
    {
        base.Display();
        System.Console.Write("Ma loai hoa: {0}", FlowerCode);
    }
    }
}