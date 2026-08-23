using UnityEngine;

/// <summary>
/// Constantes globais do jogo
/// </summary>
public static class Constants
{
    // Cenas
    public const string SCENE_MAIN_MENU = "MainMenu";
    public const string SCENE_CHARACTER_CREATION = "CharacterCreation";
    public const string SCENE_GAME_WORLD = "GameWorld";
    public const string SCENE_COMBAT = "Combat";

    // Tags
    public const string TAG_PLAYER = "Player";
    public const string TAG_ENEMY = "Enemy";
    public const string TAG_NPC = "NPC";

    // Layers
    public const string LAYER_PLAYER = "Player";
    public const string LAYER_ENEMY = "Enemy";
    public const string LAYER_ENVIRONMENT = "Environment";

    // PlayerPrefs Keys
    public const string PREF_PLAYER_NAME = "PlayerName";
    public const string PREF_PLAYER_CLASS = "PlayerClass";
    public const string PREF_PLAYER_LEVEL = "PlayerLevel";
    public const string PREF_MUSIC_VOLUME = "MusicVolume";
    public const string PREF_SFX_VOLUME = "SFXVolume";

    // Experiência
    public const int BASE_EXP_TO_LEVEL = 100;
    public const float EXP_MULTIPLIER = 1.1f;

    // Combate
    public const float TURN_DELAY = 1.5f;
    public const int MIN_DAMAGE = 5;
    public const int MAX_DAMAGE = 15;
}
