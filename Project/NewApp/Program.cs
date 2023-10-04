using NewApp.Models;

public class Program 
{
    private static void Main(string[] args)
    {
        Fruit fr1 = new Fruit();
        Fruit fr2 = new Fruit();
        Fruit fr3 = new Fruit();

        fr1.NameFruit = "Apple";
        fr1.FruitID = "fr001";
        fr1.Address = "Quang Ninh";
        fr1.Color = "Red";
        fr1.Flavor = "Sweet";
        fr1.Display();

        fr2.NameFruit = "Lemon";
        fr2.FruitID = "fr002";
        fr2.Address = "Ha Noi";
        fr2.Color = "Green";
        fr2.Flavor = "Sour";
        fr2.Display();

        fr3.NameFruit = "Chilli";
        fr3.FruitID = "fr003";
        fr3.Address = "Hai Duong";
        fr3.Color = "Red";
        fr3.Flavor = "Spicy";
        fr3.Display();
    }
}