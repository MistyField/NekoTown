using Godot;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public partial class ServerList : ScrollContainer
{
	[Export] public ItemList serverList;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		string filePath = "res://Config//server_info.json";
		using var file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);
		string content = file.GetAsText();
		file.Close();
		var serverInfo = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);
		for (int i = 0; i < serverInfo.Count; i++)
        {
            serverList.AddItem(serverInfo[i]["ip"] as string);
			serverList.SetItemTooltip(i, string.Format("端口： {0}\n用户名： {1}", serverInfo[i]["port"], serverInfo[i]["username"]));
        }
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
