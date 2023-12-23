using Godot;

public partial class Camera : Camera3D
{
	[Export]
	public Node3D Player;

	public override void _Process(double delta) =>
		Position = new Vector3(Player.Position.X - 2.5f, Player.Position.Y + 1, Player.Position.Z);
}
