using Godot;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public partial class server_config : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_button_2_pressed(){
		var scene = GD.Load<PackedScene>("res://Scenes/add_config.tscn");
		var instance = scene.Instantiate();
		AddChild(instance);
	}
	public void _on_button_3_pressed()
	{
		string filePath = "res://Config//server_info.json";
		using var file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);
		string content = file.GetAsText();
		file.Close();
		var serverInfo = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);
		int[] selectedItems = GetNode<ItemList>("MarginContainer/VSplitContainer2/VSplitContainer/ServerList/ItemList").GetSelectedItems();
		if (selectedItems.Length != 0)
		{
			int selectedIdx = selectedItems[0];
			serverInfo.RemoveAt(selectedIdx);
			using var file_save = FileAccess.Open(filePath, FileAccess.ModeFlags.Write);
			file_save.StoreString(JsonConvert.SerializeObject(serverInfo));
			file_save.Close();
			GetTree().ReloadCurrentScene();
		}
		GD.Print(JsonConvert.SerializeObject(serverInfo));
	}
	public void _on_texture_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/first_screen.tscn");
	}
}
