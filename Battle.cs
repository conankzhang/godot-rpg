using Godot;
using System;

public class Battle : Node
{
    private Enemy enemy;
    private GridContainer battleActionButtons;

    public override void _Ready()
    {
        enemy = GetNode<Enemy>("Enemy");
        battleActionButtons = GetNode<GridContainer>("UI/BattleActionButtons");
    }

    private void _on_Enemy_Died()
    {
        enemy = null;
        battleActionButtons.Hide();
    }

    private void _on_Button_pressed()
    {
        if(enemy != null)
        {
            enemy.Health -= 4;
        }
    }
}
