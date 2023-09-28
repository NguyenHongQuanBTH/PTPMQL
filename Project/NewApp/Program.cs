using System.Collections.Specialized;

internal class Program
{
    private static void Main (String [] args)
    {
        string str = "1921050489";
        int ketQua;
        bool kiemTra = false;
        kiemTra = int.TryParse(str,out(ketQua));
        System.Console.WriteLine("Ket Qua = " + ketQua);
    }
}

    

