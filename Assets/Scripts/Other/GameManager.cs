using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerPos;

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

    private void FixedUpdate()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
