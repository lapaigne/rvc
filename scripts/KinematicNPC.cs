using System;
using Godot;

public class KinematicNPC : KinematicBody2D
{
    public int HP = 100;
    public bool canDie = true;
    Label label;
    public override void _Ready()
    {
        label = GetNode<Control>("CanvasLayer/Control").GetChild<Label>(0);
        HP = 31;
    }
    public override void _PhysicsProcess(float delta)
    {
        if (HP <= 0)
        {
            OnDeath();
        }
    }
    public override void _Process(float delta)
    {
        
        label.Text = $"{HP}";
    }
    private void OnBodyEntered(Node collider) { }
    private void OnDeath()
    {
        QueueFree();
    }
}
