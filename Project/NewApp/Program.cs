using System.Collections.Specialized;
using NewApp.Models;
namespace Student;
public class Program 
{
    static void Main(String [] args)
    {
            int [] std = new int[3];
        std[0] = 7;
        std[1] = 11;
        std[2] = 12;
        int N;
        Console.WriteLine("Nhap N: ");
        N = Int32.Parse(Console.ReadLine());
        int [] k = new int[N];
        Console.WriteLine("Nhap phan tu k[{0}] = ", 3);
        k[3] = Int32.Parse(Console.ReadLine());
        for (int index = 0; index < N; index ++)
        {
            Console.WriteLine("Nhap phan tu k[{0}] = ", index);
            k[index] = Int32.Parse(Console.ReadLine());
        }
    
    }
    

}