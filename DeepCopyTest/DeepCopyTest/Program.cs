using System;
class CreditCard
{
    public string CardName { get; set; }
}
class Customer : ICloneable
{
    public int Id { get; set; }
    public CreditCard Card { get; set; }
    public object Clone()
    {
        Customer c = new Customer();
        c.Id = this.Id;
        c.Card = new CreditCard();
        c.Card.CardName = this.Card.CardName;
        return c;
    }
}
class DeepCopyTest
{
    static void Main()
    {
        Customer c1 = new Customer();
        c1.Id = 1004;
        c1.Card = new CreditCard();
        c1.Card.CardName = "비씨카드";

        Customer c2 = (Customer)c1.Clone();
        c2.Card.CardName = "BC카드";

        Console.WriteLine("c1.card.name = " + c1.Card.CardName);
        Console.WriteLine("c2.card.name = " + c2.Card.CardName);
    }
}
