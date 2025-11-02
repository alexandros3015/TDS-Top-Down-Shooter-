using Godot;

namespace tdstopdownshooter.MainMenu;
public partial class CloseGame : Button
{
    public override void _Ready()
    {
        Pressed += OnPressed;
    }

    private void OnPressed()
    {
        GetTree().Quit();
    }
}
