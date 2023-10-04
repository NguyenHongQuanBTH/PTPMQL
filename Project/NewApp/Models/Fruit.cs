namespace NewApp.Models
{
    public class Fruit
    {
        public string NameFruit { get; set; }
        public string FruitID { get; set; }
        public string Address { get; set; }
        public string Color { get; set; }
        public string Flavor { get; set; }
    
    public void EnterData()
    {
        System.Console.Write("NameFruit = ");
        NameFruit = Console.ReadLine();
        System.Console.WriteLine("FruitID = ");
        FruitID = Console.ReadLine();
        System.Console.Write("Address = ");
        Address = Console.ReadLine();
        System.Console.Write("Color = ");
        Color = Console.ReadLine();
        System.Console.Write("Flavor = ");
        Flavor = Console.ReadLine();
    }
    public void Display()
        {
            System.Console.WriteLine("{0} - {1} - {2} - {3} - {4}", NameFruit, FruitID, Address, Color, Flavor);
        }
    }
}
