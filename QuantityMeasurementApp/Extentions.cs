using System;

public static class Extentions
{
    public static void Print(this string text)
    {
        Console.WriteLine(text);
    }
}
class Program
{
    static void Main(string[] args)
    {
        "Hello".Print();
    }
}
