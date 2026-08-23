using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Gerencia o sistema de combate em turnos
/// </summary>
public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance { get; private set; }

    [SerializeField] private List<PlayerCharacter> _playerParty = new();
    [SerializeField] private List<Enemy> _enemyParty = new();
    [SerializeField] private int _currentTurn = 0;
    [SerializeField] private bool _isPlayerTurn = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    /// <summary>
    /// Inicia um combate
    /// </summary>
    public void StartCombat(List<PlayerCharacter> playerParty, List<Enemy> enemies)
    {
        _playerParty = playerParty;
        _enemyParty = enemies;
        _currentTurn = 0;
        _isPlayerTurn = true;

        Debug.Log("Combate iniciado!");
    }

    /// <summary>
    /// Executa ação de ataque
    /// </summary>
    public void PlayerAttack(PlayerCharacter attacker, Enemy target)
    {
        int damage = CalculateDamage(attacker);
        target.TakeDamage(damage);

        Debug.Log($"{attacker.CharacterName} atacou {target.name} por {damage} de dano!");

        if (target.IsDefeated())
        {
            _enemyParty.Remove(target);
            Debug.Log($"{target.name} foi derrotado!");
        }

        EndPlayerTurn();
    }

    /// <summary>
    /// Executa turno dos inimigos
    /// </summary>
    public void EnemyTurn()
    {
        if (!_isPlayerTurn) return;

        _isPlayerTurn = false;

        foreach (var enemy in _enemyParty)
        {
            if (enemy.IsDefeated()) continue;

            var target = _playerParty[Random.Range(0, _playerParty.Count)];
            int damage = CalculateDamage(enemy);
            target.TakeDamage(damage);
        }

        EndEnemyTurn();
    }

    /// <summary>
    /// Calcula dano baseado em atributos
    /// </summary>
    private int CalculateDamage(PlayerCharacter character)
    {
        return Random.Range(5, 15);
    }

    /// <summary>
    /// Calcula dano do inimigo
    /// </summary>
    private int CalculateDamage(Enemy enemy)
    {
        return Random.Range(3, 10);
    }

    private void EndPlayerTurn()
    {
        _currentTurn++;
        _isPlayerTurn = false;
        CheckCombatStatus();
    }

    private void EndEnemyTurn()
    {
        _isPlayerTurn = true;
        CheckCombatStatus();
    }

    /// <summary>
    /// Verifica se o combate terminou
    /// </summary>
    private void CheckCombatStatus()
    {
        bool allEnemiesDefeated = _enemyParty.TrueForAll(e => e.IsDefeated());
        bool allPlayersDefeated = _playerParty.TrueForAll(p => p.CurrentHealth <= 0);

        if (allEnemiesDefeated)
        {
            EndCombat(true);
        }
        else if (allPlayersDefeated)
        {
            EndCombat(false);
        }
    }

    /// <summary>
    /// Encerra o combate
    /// </summary>
    private void EndCombat(bool playerWon)
    {
        if (playerWon)
        {
            Debug.Log("Vitória! Você venceu o combate!");
        }
        else
        {
            Debug.Log("Derrota... Você foi vencido.");
        }
    }

    public bool IsPlayerTurn => _isPlayerTurn;
}
