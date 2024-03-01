using Godot;

public class Food : Item
{
    public int amount;

    public Food(int id, int amount)
        : base(id)
    {
        this.amount = amount;
    }

    public void Use(ref Player target)
    {
        target.HP = (target.HP > 0 && target.HP + amount < 100) ? target.HP + amount : target.HP;
    }
}
