using System;
using Godot;

public class Hand : KinematicBody2D
{
    private Timer timer;
    private float waitTime = 3;
    Vector2 velocity;
    int speed;
    int acceleration;
    bool isFlying;
    bool hadExploded;

    public override void _Ready()
    {
        timer = GetNode<Timer>("HandTimer");
        timer.OneShot = true;
        timer.WaitTime = waitTime;

        velocity = new Vector2();

        speed = 640;
        acceleration = 10;

        isFlying = false;
        hadExploded = false;
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("launch") && !isFlying && !hadExploded)
        {
            isFlying = true;
            timer.Start();
        }

        if (isFlying)
        {
            if (timer.TimeLeft == 0)
            {
                Explode();
            }

            var currentMouse = GetGlobalMousePosition();
            var direction = (currentMouse - GlobalPosition).Normalized();
            var targetDistance = (currentMouse - GlobalPosition).Length();

            velocity += direction * acceleration * speed;
            velocity = velocity.Normalized() * speed;
            LookAt(currentMouse);
            Rotate(Mathf.Pi / 2);

            var collision = MoveAndCollide(velocity * delta);

            if (collision != null || targetDistance < 10)
            {
                var colliderName = ((Node2D) collision.Collider).Name;
                if (colliderName == "KinematicNPC"){
                    ((KinematicNPC) collision.Collider).HP -= 30;
                }
                Explode();
            }
        }

        if (hadExploded) { }
    }

    public void OnHandLaunchTimeout()
    {
        isFlying = false;
        hadExploded = true;
    }

    public void Explode()
    {
        velocity = Vector2.Zero;
        isFlying = false;
        hadExploded = true;
        // do some stuff

        // QueueFree();
    }
}
