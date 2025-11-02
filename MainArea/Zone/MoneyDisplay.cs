using Godot;
using System;
using tdstopdownshooter.Global;

namespace tdstopdownshooter.MainArea.Zone;
public partial class MoneyDisplay : Label
{
    public override void _Process(double delta)
    {
        Text = $"Money: ${Global.Global.Money}";
    }
}
