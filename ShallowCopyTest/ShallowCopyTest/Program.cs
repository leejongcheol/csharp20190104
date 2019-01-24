using System;
class CreditCard
{
    public string CardName { get; set; };
}
class Customer
{
    public int Id { get; set; }
    public CreditCard Card { get; set; }
    public object ShallowCopy()
    {
        return this.MemberwiseClone();
    }
}
class ArrayTest
{
    static void Main()
    {
        Customer c1 = new Customer();
        c1.Id = 1004;
        c1.Card = new CreditCard();
        c1.Card.CardName = "비씨카드";

        Customer c2 = (Customer)c1.ShallowCopy();
        c2.Card.CardName = "BC카드";

        Console.WriteLine("c1.card.name = " + c1.Card.CardName);
        Console.WriteLine("c2.card.name = " + c2.Card.CardName);
    }
}

