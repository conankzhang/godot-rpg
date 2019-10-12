using Godot;
using System;

public class Battle : Node
{
    private Enemy enemy;

    public override void _Ready()
    {
        enemy = GetNode<Enemy>("Enemy");
    }

    private void _on_Button_pressed()
    {
        enemy.Health -= 4;
    }
}
