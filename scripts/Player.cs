using Godot;
using System;

public class Player : Sprite
{
	private int speed = 4;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		LookAt(GetGlobalMousePosition());
		GD.Print(RotationDegrees);
		OnRotation();

		if(Input.IsKeyPressed((int)KeyList.W))
		{
			Position += new Vector2(0, -speed);
		}
		if(Input.IsKeyPressed((int)KeyList.S))
		{
			Position += new Vector2(0, speed);
		}
		if (Input.IsKeyPressed((int)KeyList.A))
		{
			Position += new Vector2(-speed, 0);
		}
		if (Input.IsKeyPressed((int)KeyList.D))
		{
			Position += new Vector2(speed, 0);
		}
	}

	private void OnRotation()
	{
	}
}
