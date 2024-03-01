using System.Collections.Generic;
using Godot;

public class Inventory : Node2D
{
    private int _size = 16;
    public int Size
    {
        get { return _size; }
    }

    public List<Item> Storage;

    public override void _Ready()
    {
        Storage = new List<Item>();

        AddItem(3);
        AddItem(0);
        AddItem(7);
    }

    public override void _Process(float delta) { }

    public Item GetItem(int index)
    {
        if (index < Storage.Count)
            return Storage[index];
        return null;
    }

    public void AddItem(int id)
    {
        Storage.Add(new Item(id));
    }
}
