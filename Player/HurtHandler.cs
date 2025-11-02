using Godot;
namespace tdstopdownshooter.Player;

[GlobalClass]
public partial class HurtHandler : Area2D
{
    private Timer _timer;
    private bool _canShoot = true;
    public CollisionShape2D CollisionShape;
    private Timer _durationTimer;
    public override void _Ready()
    {
        CollisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
        _timer = GetNode<Timer>("Timer");
        _timer.Timeout += TimerOnTimeout;
        
        _durationTimer = GetNode<Timer>("DurationTimer");
        _durationTimer.Timeout += DurationTimerOnTimeout;
    }
    
    private void DurationTimerOnTimeout()
    {
        CollisionShape.Disabled = true;
    }

    private void TimerOnTimeout()
    {
        _canShoot = true;
    }
    

    public override void _Process(double delta)
    {
        if (!Input.IsActionJustPressed("Click") || !_canShoot) return;
        GD.Print("Starting Cooldown Timer");
        _canShoot = false;
        _timer.Start();
    
        GD.Print("Starting Duration Timer");
        CollisionShape.Disabled = false;
        _durationTimer.Start();
    }
}
