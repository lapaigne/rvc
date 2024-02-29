public class Food : Item
{
    public int Amount;
    public Food(int id, int amount) : base(id)
    {
        Amount = amount;
    }

    public override void Use()
    {
        
    }
}
