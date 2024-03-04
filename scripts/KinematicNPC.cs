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

    public override void _Process(float delta)
    {
        var label = GetNode<Control>("CanvasLayer/Control").GetChild<Label>(0);
        label.Text = $"{HP}";
    }

    private void OnBodyEntered(Node collider) { }

    private void OnDeath()
    {
        QueueFree();
    }
}
