using Godot;
using System;

public partial class OrcBody2D : CharacterBody2D
{
	[Export]
    public int Speed { get; set; } = 400;
    [Export]
    public AnimationTree AnimationTree {get; set;}
    private Vector2 _clickDirection;
    private Vector2 _targetDirection;
    private AnimationPlayer _animationPlayer;
    private Sprite2D _orcUp;
    private Sprite2D _shadowUp;
    private Sprite2D _orcDown;
    private Sprite2D _shadowDown;

    public override void _Ready()
    {        
        _clickDirection = Position;
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        AnimationTree = GetNode<AnimationTree>("AnimationTree");
        AnimationTree.Active = true;

    }

    // public override void _Process(double delta)
    // {
    //     UpdateAnimationParameters();
    // }

    public override void _PhysicsProcess(double delta)
    {   
        if(Input.IsActionJustPressed("left_click")){
            _clickDirection = GetGlobalMousePosition();
        }
        
        if(Position.DistanceTo(_clickDirection) > 3){
            _targetDirection = (_clickDirection - Position).Normalized();
            Velocity = _targetDirection * Speed;
            MoveAndSlide();
        }
        else
        {
            Velocity = Vector2.Zero;
        }

        UpdateAnimationParameters();
    }

    public void UpdateAnimationParameters()
    {
        if(Velocity == Vector2.Zero){
            AnimationTree.Set("parameters/conditions/is_idle", true);
            AnimationTree.Set("parameters/conditions/is_running", false);
        }
        else
        {
            AnimationTree.Set("parameters/conditions/is_idle", false);
            AnimationTree.Set("parameters/conditions/is_running", true);
        }

        AnimationTree.Set("parameters/idle/blend_position", _targetDirection);
        AnimationTree.Set("parameters/run_armed/blend_position", _targetDirection);
    }
}