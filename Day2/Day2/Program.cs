using System;
class Emp : object {
    public string Name
    {  //자동구현속성
        get;
        internal set;
    } = "홍길동";
}
class EmpTest {
    static void Main()     {
        Emp e = new Emp(); e.Name = "홍길동";
        string a = e.Name;
        Console.WriteLine(e.Name);
    }
}