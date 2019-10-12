using Godot;
using System;

public class Battle : Node
{
    private Enemy enemy;
    private Button swordButton;

    public override void _Ready()
    {
        enemy = GetNode<Enemy>("Enemy");
        swordButton = GetNode<Button>("UI/SwordButton");
    }

    private void _on_Enemy_Died()
    {
        enemy = null;
        swordButton.Hide();
    }

    private void _on_Button_pressed()
    {
        if(enemy != null)
        {
            enemy.Health -= 4;
        }
    }
}
