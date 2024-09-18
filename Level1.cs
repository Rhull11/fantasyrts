using Godot;
using System;

public partial class Level1 : Node2D
{

	private CharacterBody2D _orcBody2D;

	private AnimationPlayer _animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_orcBody2D = GetNode<CharacterBody2D>("OrcBody2D");
		_animationPlayer = _orcBody2D.GetChild<AnimationPlayer>(3);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_animationPlayer.Play("idle_down");
	}
}
