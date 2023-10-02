using Godot;
using System;

public class Hand : KinematicBody2D
{
    Timer timer;
    
    Vector2 velocity;
    
    int speed;
    int acceleration;
    
    bool isFlying;
    bool hadExploded;
    public override void _Ready()
    {
        timer = GetNode<Timer>("HandTimer");
        
        velocity = new Vector2();
        
        speed = 10;
        acceleration = 10;
        
        isFlying = false;
        hadExploded = false;
    }

    public override void _PhysicsProcess(float delta)
    {
        //GD.Print(velocity);
        if (Input.IsActionPressed("launch") && !isFlying && !hadExploded)
        {
            isFlying = true;
            timer.Start();
        }

        if (isFlying)
        {

            var currentMouse = GetGlobalMousePosition();
            var direction = (currentMouse - GlobalPosition).Normalized();
            var dif = (currentMouse - GlobalPosition).Length();
            GD.Print(dif);


            velocity += direction * acceleration * delta * speed;
            velocity = velocity.Normalized() * speed;

            LookAt(currentMouse);
            Rotate(Mathf.Pi / 2);
            //GD.Print(currentMouse.ToString() + "\t" + velocity.ToString());

            var collision = MoveAndCollide(velocity);
            if (collision != null || dif < 25)
            {
                hadExploded = true;
            }
        }

        if (hadExploded) 
        {
            GD.Print("Kaboom!!");
            QueueFree();
        }
    }
    public void OnHandLaunchTimeout()
    {
        isFlying = false;
        hadExploded = true;
    }
}
