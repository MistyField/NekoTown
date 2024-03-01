 using Godot;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public partial class add_config : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_window_close_requested()
	{
		var _window = GetNode<Window>("Window");
		_window.QueueFree();
	}
	public void _on_button_pressed(){
		string ip = GetNode<LineEdit>("Window/MarginContainer/VBoxContainer/VBoxContainer/HBoxContainer/LineEdit").Text;
		string port = GetNode<LineEdit>("Window/MarginContainer/VBoxContainer/VBoxContainer/HBoxContainer2/LineEdit").Text;
		string username = GetNode<LineEdit>("Window/MarginContainer/VBoxContainer/VBoxContainer/HBoxContainer3/LineEdit").Text;
		string password = GetNode<LineEdit>("Window/MarginContainer/VBoxContainer/VBoxContainer/HBoxContainer4/LineEdit").Text;
		if (ip.Length !=0 && port.Length !=0 && username.Length != 0 && password.Length != 0)
		{
			//添加服务器端判断
			string filePath = "res://Config//server_info.json";
			using var file = FileAccess.Open(filePath, FileAccess.ModeFlags.Read);
			string content = file.GetAsText();
			file.Close();
			var serverInfo = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(content);
			Dictionary<string, object> serverInfoDict = new Dictionary<string, object>();
			serverInfoDict.Add("ip", ip);
			serverInfoDict.Add("port", port);
			serverInfoDict.Add("username", username);
			serverInfoDict.Add("password", password);
			serverInfo.Add(serverInfoDict);
			using var file_save = FileAccess.Open(filePath, FileAccess.ModeFlags.Write);
			file_save.StoreString(JsonConvert.SerializeObject(serverInfo));
			file_save.Close();
			GetTree().ReloadCurrentScene();
		}
		else{
			GetNode<Label>("Window/MarginContainer/VBoxContainer/Label2").Text = "配置失败，请检查输入是否为空" ;
		}
	}
}
