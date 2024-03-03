using System;
using Godot;

public class Zone : Area2D
{
    private void _on_Area2D_body_entered(Node2D body)
    {
        GD.Print(body.Name);
    }

    public override void _Ready() { }

    public override void _Process(float delta) { }
}
