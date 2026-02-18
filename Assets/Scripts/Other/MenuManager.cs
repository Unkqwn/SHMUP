using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scenes")]
    [SerializeField] private SceneAsset GameScene;
    [SerializeField] private SceneAsset CreditsScene;
    [SerializeField] private SceneAsset MainMenuScene;

    public void StartGame()
    {
        SceneManager.LoadScene(GameScene.name);
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(CreditsScene.name);
    }

    public void HideCredits()
    {
        SceneManager.LoadScene(MainMenuScene.name);
    }

    public void QuitGame()
        {
            Application.Quit();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
    }
}
