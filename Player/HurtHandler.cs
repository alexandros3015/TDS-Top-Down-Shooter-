using Godot;
namespace tdstopdownshooter.Player;

[GlobalClass]
public partial class HurtHandler : Area2D
{
    private Timer _timer;
    public bool CanShoot = true;
    public CollisionShape2D CollisionShape;
    private Timer _durationTimer;
    public override void _Ready()
    {
        CollisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        if (CollisionShape == null)
        {
            GD.PushError($"CollisionShape2D not found in {GetPath()}");
            return;
        }

        _timer = GetNode<Timer>("Timer");
        if (_timer == null)
        {
            GD.PushError($"Timer not found in {GetPath()}");
            return;
        }
        
        _timer.Timeout += TimerOnTimeout;
        
        _durationTimer = GetNode<Timer>("DurationTimer");
        if (_durationTimer == null)
        {
            GD.PushError($"Duration Timer not found in {GetPath()}");
            return;
        }
        
        _durationTimer.Timeout += DurationTimerOnTimeout;
    }
    
    private void DurationTimerOnTimeout()
    {
        CollisionShape.Disabled = true;
    }

    private void TimerOnTimeout()
    {
        CanShoot = true;
    }
    

    public override void _Process(double delta)
    {
        if (!Input.IsActionJustPressed("Click") || !CanShoot) return;
        GD.Print("Starting Cooldown Timer");
        CanShoot = false;
        _timer.Start();
    
        GD.Print("Starting Duration Timer");
        CollisionShape.Disabled = false;
        _durationTimer.Start();
    }
}
