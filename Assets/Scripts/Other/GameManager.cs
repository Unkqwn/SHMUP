using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }

    private GameManager() { }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Victory()
    {
        SceneManager.LoadScene("Win");
    }
}
