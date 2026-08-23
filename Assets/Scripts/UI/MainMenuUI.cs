using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla a interface do menu principal
/// </summary>
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Text _titleText;

    private void Start()
    {
        _playButton.onClick.AddListener(OnPlayClicked);
        _settingsButton.onClick.AddListener(OnSettingsClicked);
        _quitButton.onClick.AddListener(OnQuitClicked);

        _titleText.text = "Star Wars RPG";
    }

    private void OnPlayClicked()
    {
        Debug.Log("Iniciando jogo...");
        GameManager.Instance.LoadScene("CharacterCreation");
    }

    private void OnSettingsClicked()
    {
        Debug.Log("Abrindo configurações...");
        // TODO: Implementar menu de configurações
    }

    private void OnQuitClicked()
    {
        Debug.Log("Saindo do jogo...");
        GameManager.Instance.QuitGame();
    }
}
