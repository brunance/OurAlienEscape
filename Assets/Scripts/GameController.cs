using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string level)
    {
        SceneManager.LoadScene(level);
    }
}
