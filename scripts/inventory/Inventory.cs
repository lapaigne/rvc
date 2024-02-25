using System;
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

    public override void _Ready() { }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta) { }

    public Item GetItem(int id)
    {
        return new Item();
    }

    public void AddItem(int id)
    {
        Storage.Add(new Item());
    }
}
