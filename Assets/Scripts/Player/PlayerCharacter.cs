using UnityEngine;

/// <summary>
/// Representa o personagem do jogador com atributos, habilidades e estado
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private string _characterName = "Padawan";
    [SerializeField] private CharacterClass _characterClass = CharacterClass.Jedi;
    [SerializeField] private int _level = 1;
    [SerializeField] private int _experience = 0;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth = 100;
    [SerializeField] private int _mana = 50;
    [SerializeField] private int _maxMana = 50;

    // Atributos base
    [SerializeField] private int _strength = 10;
    [SerializeField] private int _dexterity = 10;
    [SerializeField] private int _intelligence = 10;
    [SerializeField] private int _constitution = 10;
    [SerializeField] private int _wisdom = 10;
    [SerializeField] private int _charisma = 10;

    private int _experienceToLevelUp = 100;

    public enum CharacterClass { Jedi, Sith, Smuggler, Bounty_Hunter }

    #region Properties
    public string CharacterName => _characterName;
    public CharacterClass Class => _characterClass;
    public int Level => _level;
    public int Experience => _experience;
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public int CurrentMana => _mana;
    public int MaxMana => _maxMana;
    #endregion

    /// <summary>
    /// Sofre dano e reduz a vida
    /// </summary>
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(_currentHealth, 0);
        Debug.Log($"{_characterName} sofreu {damage} de dano. Vida: {_currentHealth}");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Cura o personagem
    /// </summary>
    public void Heal(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
        Debug.Log($"{_characterName} foi curado em {amount}. Vida: {_currentHealth}");
    }

    /// <summary>
    /// Ganha experiência e verifica level up
    /// </summary>
    public void GainExperience(int amount)
    {
        _experience += amount;
        Debug.Log($"{_characterName} ganhou {amount} de experiência");

        while (_experience >= _experienceToLevelUp)
        {
            LevelUp();
        }
    }

    /// <summary>
    /// Aumenta o nível do personagem
    /// </summary>
    private void LevelUp()
    {
        _level++;
        _experience -= _experienceToLevelUp;
        _experienceToLevelUp = (int)(_experienceToLevelUp * 1.1f);
        _maxHealth += 10;
        _currentHealth = _maxHealth;
        _maxMana += 5;
        _mana = _maxMana;

        Debug.Log($"{_characterName} subiu para o nível {_level}!");
    }

    /// <summary>
    /// Morre
    /// </summary>
    private void Die()
    {
        Debug.Log($"{_characterName} morreu...");
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Retorna a saúde como porcentagem (0-1)
    /// </summary>
    public float GetHealthPercentage() => (float)_currentHealth / _maxHealth;
}
