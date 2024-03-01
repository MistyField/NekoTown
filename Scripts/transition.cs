using Godot;
using System;

public partial class transition : Control
{
	[Export] public ColorRect colorRect;
	[Export] public AnimationPlayer animationPlayer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public async void ChangeScene(string path)
	{
		PackedScene scene = ResourceLoader.Load<PackedScene>(path);
		colorRect.Visible = true;
		animationPlayer.Play("FadeIn");
		await ToSignal(animationPlayer, "animation_finished");
		GD.Print("Animation1 finished playing.");
		GetTree().ChangeSceneToPacked(scene);
		animationPlayer.PlayBackwards("FadeIn");
		await ToSignal(animationPlayer, "animation_finished");
		GD.Print("Animation2 finished playing.");
		colorRect.Visible = false;
	}
}
