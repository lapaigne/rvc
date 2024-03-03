using System;
using Godot;

public class KinematicNPC : KinematicBody2D
{
    public int HP = 100;
    public bool canDie = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        HP = 50;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        if (HP <= 0)
        {
            OnDeath();
        }
    }

    private void OnBodyEntered(Node collider)
    {
        // GD.Print(collider.Name);
        // if (collider == null || collider == this)
        // {
        //     return;
        // }
        // HP -= 40;
    }

    private void OnDeath()
    {
        QueueFree();
    }
}
