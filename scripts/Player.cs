using System;
using System.Collections.Generic;
using Godot;

public class Player : KinematicBody2D
{
    Vector2 Velocity = new Vector2();
    int Acceleration = 10;
    const int SPEED = 160;
    bool CalledRocket = false;

    public int HP = 100;

    public override void _PhysicsProcess(float delta)
    {
        LookAt(GetGlobalMousePosition());
        Rotate(Mathf.Pi / 2);
        //var input = Input.GetVector("left", "right", "up", "down");
        var input = new Vector2();
        if (Input.IsActionPressed("left"))
        {
            input.x = -1;
        }
        if (Input.IsActionPressed("right"))
        {
            input.x = 1;
        }
        if (Input.IsActionPressed("up"))
        {
            input.y = -1;
        }
        if (Input.IsActionPressed("down"))
        {
            input.y = 1;
        }

        if (Input.IsActionPressed("launch"))
        {
            ReparentRocketHand();
        }

        input = input.Normalized();

        if (input == Vector2.Zero)
        {
            Velocity = Vector2.Zero;
        }
        else
        {
            Velocity += input * Acceleration * SPEED;
            Velocity = Velocity.Normalized() * SPEED;
        }
        MoveAndSlide(Velocity); // no delta because MAS uses it internally

        var UIControlNode = GetParent().GetNode<Control>("UICanvasLayer/UIControlNode");
        var label = UIControlNode.GetChild<Label>(0);
        var inventoryNode = GetNode<Inventory>("Inventory");
        var listData = inventoryNode.Storage;
        var strArray = new List<string>();
        foreach (var e in listData)
            strArray.Add(e.ToString());
        var listString = string.Join("\n", strArray);

        label.Text =
            $"{input}\n{Velocity}\n{Position}\n\nhp:{HP}\n\nslots:{listData.Count}\n{listString}";
    }

    public void ReparentRocketHand()
    {
        if (CalledRocket)
        {
            return;
        }
        var child = GetChild<Hand>(2);

        var gp = child.GlobalPosition;
        var gr = child.GlobalRotation;

        RemoveChild(child);

        GetNode<Main>("/root/Main").AddChild(child);

        child.GlobalPosition = gp;
        child.GlobalRotation = gr;

        CalledRocket = true;
    }
}
