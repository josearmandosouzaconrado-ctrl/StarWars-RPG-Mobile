using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gerenciador central do jogo. Controla o estado geral e coordena
/// os outros sistemas do jogo.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private string gameTitle = "Star Wars RPG";
    [SerializeField] private bool isPaused = false;

    private void Awake()
    {
        // Padrão Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.Log($"Bem-vindo a {gameTitle}!");
        Time.timeScale = 1f;
    }

    private void Update()
    {
        // Pause com ESC ou botão de pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    /// <summary>
    /// Pausa ou despausa o jogo
    /// </summary>
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        Debug.Log(isPaused ? "Jogo pausado" : "Jogo retomado");
    }

    /// <summary>
    /// Carrega uma cena pelo nome
    /// </summary>
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f; // Garante que o jogo não está pausado
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Retorna ao menu principal
    /// </summary>
    public void ReturnToMainMenu()
    {
        LoadScene("MainMenu");
    }

    /// <summary>
    /// Sai do jogo
    /// </summary>
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public bool IsPaused => isPaused;
}
