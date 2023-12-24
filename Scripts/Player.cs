using Godot;

public partial class Player : CharacterBody3D
{
    public float Speed { get; set; }

    private int deathZone;
    private const float START_SPEED = 15;
    private const float DROP_SPEED = START_SPEED / 2;
    private const float SPEED_ACCELERATION = 0.01f;
    private const int ROTATION_SPEED = 50;

    public override void _Ready()
    {
        deathZone = (int)Position.Y - 10;
        Speed = START_SPEED;
    }

    public override void _PhysicsProcess(double delta)
    {
        if ((int)Position.Y == deathZone)
            Death();

        Speed += SPEED_ACCELERATION * (RotationDegrees.Z >= 0 ? -1 : 1);
        Position = new Vector3(Position.X, Position.Y - SPEED_ACCELERATION * ((0 - RotationDegrees.Z) / 90), Position.Z);

        Vector3 velocity = Position.DirectionTo(GetNode<Marker3D>("PlayerVector").GlobalPosition) * Speed;        
        
        Velocity = velocity;
        ChangeDirection(delta);
        MoveAndSlide();
    }

    private void ChangeDirection(double delta)
    {
        if (Input.IsActionPressed("Up"))
            RotationDegrees = new Vector3(RotationDegrees.X, RotationDegrees.Y, RotationDegrees.Z + ROTATION_SPEED * (float)delta);
        else if (Input.IsActionPressed("Down"))
            RotationDegrees = new Vector3(RotationDegrees.X, RotationDegrees.Y, RotationDegrees.Z - ROTATION_SPEED * (float)delta);

        if (Speed < DROP_SPEED && RotationDegrees.Z > -70)
        {
            float k = Speed < 2 ? 1.6f : 1;
            RotationDegrees = new Vector3(RotationDegrees.X, RotationDegrees.Y, RotationDegrees.Z - (DROP_SPEED - Speed) / DROP_SPEED * ROTATION_SPEED * k * (float)delta);
        }
    }

    private void Death()
    {
        GD.Print("Player death!");
        //Code...
    }
}