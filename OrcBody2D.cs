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
        _orcUp = GetNode<Sprite2D>("OrcSpriteUp");
        _shadowUp = GetNode<Sprite2D>("ShadowSpriteUp");
        _orcDown = GetNode<Sprite2D>("OrcSprite");
        _shadowDown = GetNode<Sprite2D>("ShadowSprite");
    }

    public override void _Process(double delta)
    {
         //_animationPlayer.Play("idle_down");
        
        if(Input.IsActionJustPressed("left_click")){
            _clickDirection = GetGlobalMousePosition();
        }
        
        if(Position.DistanceTo(_clickDirection) > 3){
            _targetDirection = (_clickDirection - Position).Normalized();
            Velocity = _targetDirection.Normalized() * Speed;
            MoveAndSlide();
        }

        AnimationTree.Set("parameters/idle/blend_position", Velocity);
    }
}