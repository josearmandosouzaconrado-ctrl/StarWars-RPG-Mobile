using UnityEngine;

/// <summary>
/// Representa uma missão/quest no jogo
/// </summary>
public class Quest : ScriptableObject
{
    [SerializeField] private string _questName = "";
    [SerializeField] private string _description = "";
    [SerializeField] private QuestType _questType = QuestType.Side;
    [SerializeField] private int _experienceReward = 100;
    [SerializeField] private int _goldReward = 50;
    [SerializeField] private bool _isCompleted = false;
    [SerializeField] private int _progress = 0;
    [SerializeField] private int _maxProgress = 1;

    public enum QuestType { Main, Side, Daily }

    #region Properties
    public string QuestName => _questName;
    public string Description => _description;
    public QuestType Type => _questType;
    public int ExperienceReward => _experienceReward;
    public int GoldReward => _goldReward;
    public bool IsCompleted => _isCompleted;
    public int Progress => _progress;
    public int MaxProgress => _maxProgress;
    public float ProgressPercentage => (float)_progress / _maxProgress;
    #endregion

    /// <summary>
    /// Aumenta o progresso da missão
    /// </summary>
    public void AdvanceProgress(int amount = 1)
    {
        _progress += amount;
        _progress = Mathf.Min(_progress, _maxProgress);

        if (_progress >= _maxProgress)
        {
            CompleteQuest();
        }
    }

    /// <summary>
    /// Completa a missão
    /// </summary>
    public void CompleteQuest()
    {
        _isCompleted = true;
        Debug.Log($"Missão '{_questName}' completada! Você recebeu {_experienceReward} XP e {_goldReward} ouro.");
    }

    /// <summary>
    /// Reseta a missão
    /// </summary>
    public void ResetQuest()
    {
        _isCompleted = false;
        _progress = 0;
    }
}
