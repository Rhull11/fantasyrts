using Godot;
using System;

public partial class OrcBody2D : CharacterBody2D
{
	[Export]
    public int Speed { get; set; } = 400;

    private Vector2 clickDirection;
    private Vector2 targetDirection;

    public override void _Ready()
    {        
        clickDirection = Position;
    }

    public override void _PhysicsProcess(double delta)
    {
        
        if(Input.IsActionJustPressed("left_click")){
            clickDirection = GetGlobalMousePosition();
        }
        
        if(Position.DistanceTo(clickDirection) > 3){
            targetDirection = (clickDirection - Position).Normalized();
            Velocity = targetDirection.Normalized() * Speed;
            MoveAndSlide();
        }

    }
}
