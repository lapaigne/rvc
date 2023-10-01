using Godot;
using System;

public class Player : KinematicBody2D
{
    Vector2 velocity = new Vector2();
    int acceleration = 2000;
    int deceleration = 250;
    const int speed = 200;

    public override void _PhysicsProcess(float delta)
    {
        var input = Input.GetVector("left", "right", "up", "down");
        if (input == Vector2.Zero)
        {
            velocity = (velocity.Length() > (delta * acceleration)) ? velocity - velocity.Normalized() * deceleration * delta : Vector2.Zero;
        }
        else
        {
            velocity += input * acceleration * delta;
            velocity = velocity.Normalized() * speed;
        }
        velocity = MoveAndSlide(velocity);
    }
}
