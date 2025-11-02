using System;
using Godot;
// Range: 642 px

namespace tdstopdownshooter.MainArea.SpawnArea;

public partial class SpawnArea : Node2D
{
    private Timer _timer;
    private RandomNumberGenerator _rng;

    public override void _Ready()
    {
        _rng = new RandomNumberGenerator();
        _rng.Randomize();
        _timer = GetNode<Timer>("Timer");
        _timer.Timeout += TimerOnTimeout;
    }

    private void TimerOnTimeout()
    {
        var enemyScene = ResourceLoader.Load<PackedScene>("res://Enemy/EnemyBasic/EnemyBasic.tscn");
        var enemy = enemyScene.Instantiate<Node2D>();
        AddSibling(enemy);
        enemy.Position = new Vector2(0f, _rng.RandfRange(30, 642));

        _timer.WaitTime = MathF.Max(0.5f, Global.Global.Difficulty * -0.2f + 10f);
    }
}
