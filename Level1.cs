using Godot;
using System;

public partial class Level1 : Node2D
{

	private CharacterBody2D _orcBody2D;
	private AnimatedSprite2D _orcAnimatedSprite2D;
	private AnimatedSprite2D _shadowAnimatedSprite2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_orcBody2D = GetNode<CharacterBody2D>("OrcBody2D");
		_orcAnimatedSprite2D = _orcBody2D.GetChild<AnimatedSprite2D>(0);
		_shadowAnimatedSprite2D = _orcBody2D.GetChild<AnimatedSprite2D>(1);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_orcAnimatedSprite2D.Play("idle_armed");
		_shadowAnimatedSprite2D.Play("idle_shadow_armed");
	}
}
