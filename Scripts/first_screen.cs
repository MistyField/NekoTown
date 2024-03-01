using Godot;
using System;

public partial class first_screen : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			// 带有过渡动画的场景切换 Transition是全局加载的节点，需要调整zindx创建遮罩效果
			transition Transition = GetNode<transition>("/root/Transition");
			Transition.ZIndex = 128;
			Transition.ChangeScene("res://Scenes/server_config.tscn");
		}
	}
}
