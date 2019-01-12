using System;
class Garbage : IDisposable
{
    private bool isDispose = false;
    private string name;

    public Garbage(string name)
    {
        this.name = name;
        Console.WriteLine("{0}객체 생성됨...", this.name);
    }
    ~Garbage()
    {
        if (!isDispose) { Dispose(); }
    }
    public void Dispose()
    {
        isDispose = true;
        //... 리소스를 해제함...
        Console.WriteLine("{0}객체의 리소스 해제 OK...", name); GC.SuppressFinalize(this);
    }
}

class GarbageTest1
{
    static void Main()
    {
        Garbage g1 = new Garbage("1번객체"); Garbage g2 = new Garbage("2번객체");
        Garbage g3 = new Garbage("3번객체"); Garbage g4 = new Garbage("4번객체");

        g1.Dispose();
        GC.SuppressFinalize(g2);
        Console.ReadLine();
    }
}
