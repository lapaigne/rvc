using Godot;
using System;

public class Player : KinematicBody2D
{
    Vector2 velocity = new Vector2();
    int acceleration = 500;
    int deceleration = 250;
    const int speed = 200;
    bool calledRocket = false;

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
            //ReparentRocketHand(ref calledRocket);
        }

        input = input.Normalized();

        var label = GetNode<Label>("/root/Main/vel");

        if (input == Vector2.Zero)
        {
            velocity = (velocity.Length() > (delta * acceleration)) ? velocity - velocity.Normalized() * deceleration * delta : Vector2.Zero;
        }
        else
        {
            GD.Print(velocity);
            velocity += input * acceleration * delta * speed;
            velocity = velocity.Normalized() * speed;
        }
        velocity = MoveAndSlide(velocity);
        label.Text = input.ToString() + "\n" + velocity.ToString() + "\n" + Position.ToString();
    }

    public void ReparentRocketHand(ref bool called)
    {
        // yet to figure out a way to transfer global coords et rotation

        if (called)
        {
            return;
        }
        var child = GetNode<Hand>("Hand");
        RemoveChild(child);

        var gp = child.GlobalPosition;
        var gr = child.GlobalRotation;

        var node = GetNode<Main>("/root/Main");
        node.AddChild(child);


        //child.GlobalPosition = gp;
        //child.GlobalRotation = gr;


        calledRocket = true;
    }
}
