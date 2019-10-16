using Godot;
using System;

public class Battle : Node
{
    private Enemy enemy;
    private GridContainer battleActionButtons;
    private PlayerStats playerStats;

    public override void _Ready()
    {
        enemy = GetNode<Enemy>("Enemy");
        playerStats = GetNode<PlayerStats>("PlayerStats");
        battleActionButtons = GetNode<GridContainer>("UI/BattleActionButtons");

        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        battleActionButtons.Show();
        playerStats.CurrentActionPoints = playerStats.MaxActionPoints;
        WaitForPlayerTurnEnded();
    }

    private void StartEnemyTurn()
    {
        battleActionButtons.Hide();
        if(enemy != null)
        {
            enemy.Attack(playerStats);
        }
        WaitForEnemyTurnEnded();
    }

    private async void WaitForPlayerTurnEnded()
    {
        await ToSignal(playerStats, "TurnEnded");
        StartEnemyTurn();
    }

    private async void WaitForEnemyTurnEnded()
    {
        await ToSignal(enemy, "TurnEnded");
        StartPlayerTurn();
    }

    private void _on_Enemy_Died()
    {
        enemy = null;
        battleActionButtons.Hide();
    }
}
