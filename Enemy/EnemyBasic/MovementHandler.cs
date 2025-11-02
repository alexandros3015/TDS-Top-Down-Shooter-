using Godot;

namespace tdstopdownshooter.Enemy.EnemyBasic;

public partial class MovementHandler : Node
{
    private Node2D _target;
    
    [Export]
    public float  Speed = 50f;

    public override void _Ready()
    {
        _target = GetParent<Node2D>();

        if (_target == null)
        {
            GD.PushError("Could not find target");
        }
    }

    public override void _Process(double delta)
    {
        if (_target == null)
        {
            return;
        }

        var dt = (float)delta;
        _target.Position += new Vector2(Speed * dt, 0f);
    }
}
