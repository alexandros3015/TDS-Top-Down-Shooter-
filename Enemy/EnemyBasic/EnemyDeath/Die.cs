using Godot;
using System;

namespace tdstopdownshooter.Enemy.EnemyBasic.EnemyDeath;
public partial class Die : GpuParticles2D
{
    [Export] public Timer ExpireTimer;
    public override void _Ready()
    {
        Emitting = true;
        
        ExpireTimer.Timeout += DieOnTimeout;
    }
    
    private void DieOnTimeout()
    {
        Emitting = false;
        QueueFree();
    }
    
    
}
