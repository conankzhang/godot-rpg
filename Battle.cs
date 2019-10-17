using Godot;
using System;

public class Battle : Node
{
    [Export]
    private PackedScene slime;

    [Export]
    private PackedScene rat;

    private Enemy enemy;
    private GridContainer battleActionButtons;
    private PlayerStats playerStats;
    private AnimationPlayer animationPlayer;
    private Button nextRoomButton;
    private Position2D enemyPosition;

    public override void _Ready()
    {
        playerStats = GetNode<PlayerStats>("PlayerStats");
        battleActionButtons = GetNode<GridContainer>("UI/BattleActionButtons");
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        nextRoomButton = GetNode<Button>("UI/CenterContainer/NextRoomButton");
        enemyPosition = GetNode<Position2D>("EnemyPosition");

        CreateNewEnemy();
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

    private void _on_NextRoomButton_pressed()
    {
        nextRoomButton.Hide();
        animationPlayer.Play("FadeToNewRoom");
        WaitForFadeToNewRoom();
    }

    private async void WaitForFadeToNewRoom()
    {
        await ToSignal(animationPlayer, "animation_finished");
        battleActionButtons.Show();
        playerStats.CurrentActionPoints = playerStats.MaxActionPoints;
        CreateNewEnemy();
    }

    private void CreateNewEnemy()
    {
        Random random = new Random();
        if(random.NextDouble() < 0.5d)
        {
            enemy = rat.Instance() as Enemy;
        }
        else
        {
            enemy = slime.Instance() as Enemy;
        }

        enemy.SetName("Enemy");
        enemy.Connect("Died", this, nameof(_on_Enemy_Died));
        enemyPosition.AddChild(enemy);
    }

    public void _on_Enemy_Died()
    {
        nextRoomButton.Show();
        battleActionButtons.Hide();
    }
}
