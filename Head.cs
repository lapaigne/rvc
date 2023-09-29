using Godot;
using System;

public class Head : Sprite
{
    private int speed = 4;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //var leftHeaded = ResourceLoader.Load("res://kbrgs pics/head/default_deactivated.png") as Texture;
        this.FlipH = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        LookAt(GetGlobalMousePosition());
        GD.Print(this.RotationDegrees);
        OnRotation();

        if(Input.IsKeyPressed((int)KeyList.W))
        {
            this.Position += new Vector2(0, -speed);
        }
        if(Input.IsKeyPressed((int)KeyList.S))
        {
            this.Position += new Vector2(0, speed);
        }
        if (Input.IsKeyPressed((int)KeyList.A))
        {
            this.Position += new Vector2(-speed, 0);
        }
        if (Input.IsKeyPressed((int)KeyList.D))
        {
            this.Position += new Vector2(speed, 0);
        }
    }

    private void OnRotation()
    {
        RotationDegrees = (RotationDegrees + 360) % 360;

        if (RotationDegrees > 90 && RotationDegrees<270) {
            FlipV = true;
        }
        else
        {
            FlipV = false;
        }
    }
}
