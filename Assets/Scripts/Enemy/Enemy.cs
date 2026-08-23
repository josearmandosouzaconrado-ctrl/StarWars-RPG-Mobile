using UnityEngine;

/// <summary>
/// Representa um inimigo genérico no jogo
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField] private string _enemyName = "Inimigo";
    [SerializeField] private int _level = 1;
    [SerializeField] private int _maxHealth = 50;
    [SerializeField] private int _currentHealth = 50;
    [SerializeField] private int _damage = 5;
    [SerializeField] private int _experienceReward = 50;
    [SerializeField] private int _goldReward = 25;

    #region Properties
    public string EnemyName => _enemyName;
    public int Level => _level;
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public bool IsDefeated => _currentHealth <= 0;
    #endregion

    /// <summary>
    /// Sofre dano
    /// </summary>
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(_currentHealth, 0);
        Debug.Log($"{_enemyName} sofreu {damage} de dano. Saúde: {_currentHealth}/{_maxHealth}");
    }

    /// <summary>
    /// Verifica se foi derrotado
    /// </summary>
    public bool IsDefeated()
    {
        return _currentHealth <= 0;
    }

    /// <summary>
    /// Retorna recompensas ao vencer
    /// </summary>
    public (int experience, int gold) GetRewards()
    {
        return (_experienceReward, _goldReward);
    }

    /// <summary>
    /// Reseta o inimigo
    /// </summary>
    public void Reset()
    {
        _currentHealth = _maxHealth;
    }
}
