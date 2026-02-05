using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private PlayerAttackHP HP;
    private BossHealth hp;
    private void Awake()
    {
        HP = GetComponent<PlayerAttackHP>();
        hp = GetComponent<BossHealth>();
    }
   
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Game()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Quit() 
    {
        Application.Quit();
    }
}
