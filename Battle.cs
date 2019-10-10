using Godot;
using System;

public class Battle : Node
{
    private Label healthLabel;

    public override void _Ready()
    {
        healthLabel = GetNode<Label>("Enemy/HPLabel");
    }

    private void _on_Button_pressed()
    {
        healthLabel.SetText("15 hp");
    }
}
