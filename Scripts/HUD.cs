using Godot;
using System;

public partial class HUD : Control
{
	[Export]
	public Player Player;

	public override void _Process(double delta)
	{
		GetNode<Label>("Speed").Text = $"Скорость = {Convert.ToString(Player.Speed)}м/с";
		GetNode<Label>("Height").Text = $"Высота = {Convert.ToString(Player.Position.Y)}м";
	}
}
